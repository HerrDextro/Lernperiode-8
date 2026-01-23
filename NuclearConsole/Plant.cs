using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.Intrinsics.X86;
using System.Text;

namespace NuclearConsole
{
    public class Plant
    {
        public MainCooling mainCooling;
        Turbine turbine;
        TurbineGovernor governor;
        AutoVoltRegulator regulator;
        Generator generator;
        Synchronizer synchronizer;
        Grid grid;

        bool breakerClosed;
        public Plant(MainCooling mainCooling, Turbine turbine, TurbineGovernor turbineGovernor, AutoVoltRegulator avr, Generator generator, Synchronizer synchronizer, Grid grid) 
        {
            this.mainCooling = mainCooling;
            this.turbine = turbine;
            governor = turbineGovernor;
            regulator = avr;
            this.generator = generator;
            this.synchronizer = synchronizer;
            this.grid = grid;
        
        }

        public void Update(double dt)
        {
            // update governor, AVR, turbine, generator, apply grid lock
            governor.Update(dt, turbine, generator);
            regulator.Update(dt, generator);

            turbine.Update(dt);

            if (!breakerClosed && synchronizer.CanClose(generator, grid))
            {
                breakerClosed = true;
            }

            if (breakerClosed)
            {
                turbine.Rpm = grid.RpmForPoles(generator.Poles);
            }

            //LATER ADD SYNC STILLSAFE (OPENS BREAKER IF GRID LOCK FAIL)
        }

    }
}
