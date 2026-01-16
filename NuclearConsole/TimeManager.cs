using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    static class TimeManager
    {
        
        
        public static double GetUptimeMinutes()
        {
            DateTime _starttime = DateTime.Now;
            TimeSpan uptime = DateTime.Now - _starttime;
            double minutes = uptime.TotalMinutes;
            return minutes;
        }
        public static TimeSpan GetUptimeTotal()
        {
            DateTime _starttime = DateTime.Now;
            TimeSpan uptime = DateTime.Now - _starttime;
            return uptime;
        }
    }
}
