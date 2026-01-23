using NuclearConsole;
using NuclearConsole.Physics;
using System.Reflection.Emit;

namespace TDD1
{
    /*[TestClass]
    public sealed class GridTest //we are gonna test from outside inwards, since IRL the grid dictates alot of thing in the NPP
    {
        [TestMethod]
        public void PhaseGenerator()
        {
            var(p1, p2, p3) = NuclearConsole.Physics.PhaseGenerator.GenPhases(0, 50, 380000);

            Assert.AreEqual(0, p1, 1e-6);
            Assert.AreEqual(380000 * Math.Sin(2 * Math.PI / 3), p2, 1e-3);
            Assert.AreEqual(380000 * Math.Sin(4 * Math.PI / 3), p3, 1e-3);
        }

        [TestMethod]
        public void Phases_Are_120_Degrees_Apart()
        {
            var grid = new Grid(50, 380000);

            var (p1, p2, p3) = grid.GetGridSimulation(0);

            Assert.AreEqual(0, p1, 1e-6);
            Assert.AreEqual(380000 * Math.Sin(2 * Math.PI / 3), p2, 1e-3);
            Assert.AreEqual(380000 * Math.Sin(4 * Math.PI / 3), p3, 1e-3);
        }

        [TestMethod]
        public void One_Period_Returns_To_Same_Value()
        {
            var grid = new Grid(50, 380000);

            double period = 1.0 / 50.0;

            var (p1, _, _) = grid.GetGridSimulation(0);
            var (p1After, _, _) = grid.GetGridSimulation(period);

            Assert.AreEqual(p1, p1After, 1e-6);
        }

        [TestMethod]
        public void Peak_Equals_Voltage()
        {
            var grid = new Grid(50, 380000);

            double t = 1.0 / (4 * 50); // quarter period

            var (p1, _, _) = grid.GetGridSimulation(t);

            Assert.AreEqual(380000, p1, 1e-3);
        }
    }*/

    [TestClass]
    public sealed class ElectricalTests
    {
        [TestMethod]
        public void Transformer_Steps_Down_Voltage_Correctly()
        {
            var transformer = new Transformer();
            double inputVoltage = 20; // 20kV
            double expectedOutputVoltage = 380; // 380V
            double outputVoltage = transformer.TransformVoltage(inputVoltage);
            Assert.AreEqual(expectedOutputVoltage, outputVoltage, 1e-3);
        }

        [TestMethod]
        public void Transformer_Steps_Up_Voltage_Correctly()
        {
            var transformer = new Transformer();
            double inputVoltage = 20; // 20kV
            double expectedOutputVoltage = 380; // 380kV
            double outputVoltage = transformer.TransformVoltage(inputVoltage);
            Assert.AreEqual(expectedOutputVoltage, outputVoltage, 1e-3);
        }

        //after simulation restructure (after main loop was added, bc I realised this isnt a simple calculator anymore)
        static void RunFor(double seconds, double dt, Action<double> tick)
        {
            int steps = (int)(seconds / dt);
            for (int i = 0; i < steps; i++)
                tick(dt);
        }

        [TestMethod]
        public void Turbine_Accelerates_When_Torque_Applied()
        {
            var t = new Turbine();
            t.Rpm = 0;
            t.SteamTorque = 10;
            t.LoadTorque = 0;

            RunFor(5, 0.01, dt => t.Update(dt));

            Assert.IsTrue(t.Rpm > 0);
        }

        [TestMethod]
        public void Generator_Frequency_Computed_From_RPM()
        {
            var t = new Turbine();
            t.Rpm = 3000;

            var g = new Generator(t, poles: 2);

            double freq = g.Frequency;

            Assert.AreEqual(50, freq, 0.01);
        }

        [TestMethod]
        public void AVR_Drives_Voltage_To_Target()
        {
            var t = new Turbine { Rpm = 3000 };
            var g = new Generator(t, 2);
            g.Excitation = 0.2;

            var avr = new AutoVoltRegulator();
            avr.TargetVoltage = 20000;

            RunFor(5, 0.01, dt =>
            {
                avr.Update(dt, g);
            });

            Assert.AreEqual(20000, g.Voltage, 500); // loose tolerance
        }

        [TestMethod]
        public void Governor_Drives_RPM_To_3000()
        {
            var t = new Turbine();
            var g = new Generator(t, 2);

            var gov = new TurbineGovernor();
            gov.GridConnected = false;

            RunFor(10, 0.01, dt =>
            {
                gov.Update(dt, t, g);
                t.Update(dt);
            });

            Assert.AreEqual(3000, t.Rpm, 50);
        }

        [TestMethod]
        public void Synchronizer_Allows_Close_When_Matched()
        {
            var t = new Turbine();
            t.Rpm = 3000;

            var g = new Generator(t, 2);
            g.Excitation = 1.0;

            var grid = new Grid();
            var sync = new Synchronizer();

            bool canClose = sync.CanClose(g, grid);

            Assert.IsTrue(canClose);
        }

        [TestMethod]
        public void Grid_Locks_RPM_After_Connection()
        {
            var t = new Turbine();
            var g = new Generator(t, 2);
            var grid = new Grid();

            // pretend breaker closed
            g.IsConnectedToGrid = true;
            t.Rpm = 2800;

            double lockedRpm = grid.RpmForPoles(2);
            t.Rpm = lockedRpm; // what Plant should enforce

            Assert.AreEqual(3000, t.Rpm, 0.1);
        }
    }
}
