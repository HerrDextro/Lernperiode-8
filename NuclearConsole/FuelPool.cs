using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    class FuelPool
    {
        List<FuelRod> spentFuelRods;
        public FuelPool()
        {
            spentFuelRods = new List<FuelRod>();
        }

        public void StoreSpentFuelRods(List<FuelRod> rodsToStore)
        {
            spentFuelRods = rodsToStore;
        }

        public void InspectSpentFuelRods()
        {
            //Implementation for inspecting spent fuel rods
        }
        public void DisposeSpentFuelRods()
        {
            spentFuelRods.Clear();
        }
    }
}
