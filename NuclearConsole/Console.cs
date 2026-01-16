using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace NuclearConsole
{
    class Console
    {
        Core reactorCore;
        MainCooling mainCoolingSystem;
        SecondaryCooling secondaryCoolingSystem;
        //start with easiest: current power output.
        public void ConfigReactor() //configure NPP layout, core manages fuel pool
        {
            //starting with basics (10 fuel rods, 5 control rods, 2 main pumps at 100 FR, 3 secondary pumps at 10 FR) Note: flowrate is a cap (max)
            reactorCore = new Core(10, 5);
            mainCoolingSystem = new MainCooling(2, 100);
            secondaryCoolingSystem = new SecondaryCooling(3, 10);

            DisplayAll();
        }

        public void DisplayAll()
        {
            reactorCore.DisplayReactorStatus();
            mainCoolingSystem.DisplayCoolingStatus();
        }



    }
}
