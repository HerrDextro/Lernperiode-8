using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    class FuelRod
    {
        public double usagePercent; //0-100 //every minute of use increases by 1%
        public int radsPerSecond; //rads per second 

        public FuelRod()
        {
            usagePercent = 0;
            radsPerSecond = 10;
        }
        public void Update(double dt)
        {
            // 1% per minute => 1 / 60 % per second
            usagePercent += (1.0 / 60.0) * dt;
            usagePercent = Math.Min(100, usagePercent);
        }
    }
}
