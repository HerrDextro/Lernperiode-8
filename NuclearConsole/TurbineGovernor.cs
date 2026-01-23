using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    public class TurbineGovernor
    {
        public double TargetRpm = 3000;
        public double TargetPower = 1_000_000_000; // 1 GW
        public double Gain = 0.1;

        public bool GridConnected;

        public void Update(double dt, Turbine turbine, Generator gen)
        {
            double error;

            if (!GridConnected)
            {
                error = TargetRpm - turbine.Rpm;
            }
            else
            {
                double power = turbine.LoadTorque * turbine.Rpm;
                error = TargetPower - power;
            }

            turbine.SteamTorque += error * Gain * dt;
        }
    }

}
