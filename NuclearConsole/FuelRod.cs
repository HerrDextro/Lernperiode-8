using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    class FuelRod
    {
        public int usagePercent; //0-100 //every minute of use increases by 1%
        public int radsPerSecond; //rads per second 

        public int UsagePercent
        {
            get { return usagePercent + Convert.ToInt16(TimeManager.GetUptimeMinutes); } //oko for now, add extra usage for highter heat outputs later
            set { usagePercent = value; }
        }

        public FuelRod()
        {
            usagePercent = 0;
            radsPerSecond = 10;
        }
    }
}
