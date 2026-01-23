using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    public class Synchronizer
    {
        public bool CanClose(Generator gen, Grid grid)
        {
            bool freqOk = Math.Abs(gen.Frequency - grid.Frequency) < 0.1;
            bool voltOk = Math.Abs(gen.Voltage - grid.Voltage) / grid.Voltage < 0.05;

            double phaseDiff = Math.Abs((gen.PhaseAngle % (2 * Math.PI))); //module for double kinda cursed, ask AI or sum
            bool phaseOk = phaseDiff < 0.1 || Math.Abs(phaseDiff - 2 * Math.PI) < 0.1;

            return freqOk && voltOk && phaseOk;
        }
    }

}
