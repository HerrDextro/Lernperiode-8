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
                pumps.Add(new Pump("sp" + (i+=1))); //names pumps sp1, sp2 etc (secondary pump)
                flowRate += pumpFlowRate;
            }
        }
    }
}
