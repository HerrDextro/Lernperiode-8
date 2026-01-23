using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    public class Pump
    {
        public string identifier;
        public string pumpStatus;
        public int flowRate;
        public Pump(string identifier)
        {
            this.identifier = identifier;
            pumpStatus = "Online";
            flowRate = 100; //default flow rate
        }
        public void SetSpeed(int newFlowRate)
        {
            flowRate = newFlowRate;
        }

    }
}
