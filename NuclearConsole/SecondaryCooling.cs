using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    class SecondaryCooling
    {
        public int flowRate; //sum of all pumps
        int _coolantTemp;
        List<Pump> pumps;
        public SecondaryCooling(int numPumps, int pumpFlowRate)
        {
            pumps = new List<Pump>();
            for (int i = 0; i < numPumps; i++)
            {
                pumps.Add(new Pump());
                flowRate += pumpFlowRate;
            }
        }
    }
}
