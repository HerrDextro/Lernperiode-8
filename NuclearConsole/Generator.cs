using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    public class Generator
    {
        public Turbine Turbine;
        public int Poles;
        public double BaseVoltage = 20000; // 20kV
        public double Excitation = 1.0;

        public bool IsConnectedToGrid;

        public Generator(Turbine turbine, int poles)
        {
            Turbine = turbine;
            Poles = poles;
        }

        public double Frequency => Turbine.Rpm * Poles / 120.0;
        public double Voltage => BaseVoltage * Excitation;

        public double PhaseAngle => Turbine.AngleRad; //gen.PhaseAngle % (2 * Math.PI)


        public void Update(double dt)
        {
            if (IsConnectedToGrid)
            {
                // Grid will override RPM elsewhere
            }
        }
    }

}
