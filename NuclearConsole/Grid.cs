using NuclearConsole.Physics;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole //test this later
{
    public class Grid
    {
        public double Frequency = 50;
        public double Voltage = 380_000;

        public double RpmForPoles(int poles) => 120.0 * Frequency / poles;
    }

}
