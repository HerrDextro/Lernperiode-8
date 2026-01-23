using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    public class AutoVoltRegulator
    {
        public double TargetVoltage;
        public double Gain = 0.5;

        public void Update(double dt, Generator gen)
        {
            double error = TargetVoltage - gen.Voltage;
            gen.Excitation += error * Gain * dt / gen.BaseVoltage;
            gen.Excitation = Math.Clamp(gen.Excitation, 0.0, 1.2);
        }
    }

}
