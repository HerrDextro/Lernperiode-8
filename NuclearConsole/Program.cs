using System.Text.Unicode;
using System.Diagnostics;

namespace NuclearConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Nuclear Console Application Running on .NET 10.0 with C# 14.0");
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            //init all part of NPP prreconfigd
            Core reactorCore = new Core(12, 5);
            MainCooling mainCooling = new MainCooling(2, 100);
            SecondaryCooling secondaryCooling = new SecondaryCooling(3, 10);
            Turbine turbine = new Turbine();
            TurbineGovernor turbineGovernor = new TurbineGovernor();
            Generator generator = new Generator(turbine, 2);
            AutoVoltRegulator regulator = new AutoVoltRegulator();
            Synchronizer synchronizer = new Synchronizer();
            Transformer transformer = new Transformer();
            Grid grid = new Grid();

            Plant plant = new Plant(mainCooling, turbine, turbineGovernor, regulator, generator, synchronizer, grid);
            UI panel = new UI(plant, reactorCore, mainCooling, secondaryCooling, turbine, generator, grid);

            //loop logic all here below
            var sw = Stopwatch.StartNew();
            double lastTime = sw.Elapsed.TotalSeconds;

            //for testclass dummy ui testing
            //Testclass.TestMethod3();

            const double dt = 0.02;
            while (true)
            {
                /*double now = sw.Elapsed.TotalSeconds;
                double dt = now - lastTime;
                lastTime = now;*/

                //maybe change to fix 20ms time (50Hz) by thread sleep 20 and dt = 0.02

                plant.Update(dt);
                panel.Render(); //deactivated for TestClass

                Thread.Sleep(20); //otherwise 16 60fps
            }
        }
        /*public void ConfigReactor() //configure NPP layout, core manages fuel pool (do at start)
        {
            //starting with basics (10 fuel rods, 5 control rods, 2 main pumps at 100 FR, 3 secondary pumps at 10 FR) Note: flowrate is a cap (max)
            Core reactorCore = new Core(10, 5);
            MainCooling mainCoolingSystem = new MainCooling(2, 100);
            SecondaryCooling secondaryCoolingSystem = new SecondaryCooling(3, 10);
        }*/
    }
}