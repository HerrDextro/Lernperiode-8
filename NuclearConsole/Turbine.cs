using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    public class Turbine
    {
        public double Rpm;
        public double AngleRad;
        public double SteamTorque; // control input
        public double LoadTorque;  // from generator
        public double Inertia = 10;

        public void Update(double dt)
        {
            double accel = (SteamTorque - LoadTorque) / Inertia;
            Rpm += accel * dt;

            double omega = Rpm * 2 * Math.PI / 60.0;
            AngleRad += omega * dt;
        }
    }

}
