using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole.Physics
{
    public static class PhaseGenerator
    {
        public static (double p1, double p2, double p3) GenPhases(double timeSeconds, int frequency, int voltage) //voltage int is 1 to1 
        {
            double angularFrequency = 2 * Math.PI * frequency; // in radians per second
            double p1 = voltage * Math.Sin(angularFrequency * timeSeconds + 0); //phase 1
            double p2 = voltage * Math.Sin(angularFrequency * timeSeconds + (2 * Math.PI / 3)); //phase 2
            double p3 = voltage * Math.Sin(angularFrequency * timeSeconds + (4 * Math.PI / 3)); //phase 3

            return (p1, p2, p3);
        }

        public static (double p1, double p2, double p3) GenPhasesFromAngle(double angle, double voltage)
        {
            double p1 = voltage * Math.Sin(angle);
            double p2 = voltage * Math.Sin(angle + 2 * Math.PI / 3);
            double p3 = voltage * Math.Sin(angle + 4 * Math.PI / 3);
            return (p1, p2, p3);
        }



    }
}
