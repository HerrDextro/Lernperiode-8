using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    internal class Pump
    {
        public string pumpStatus;
        public int flowRate;
        public Pump()
        {
            pumpStatus = "Online";
            flowRate = 100; //default flow rate
        }
        public void SetSpeed(int newFlowRate)
        {
            flowRate = newFlowRate;
        }

    }
}
