using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    class Generator
    {
        int V;
        int A;
        public int rotPos;
        public int powerOutput; //in megawatts probably
        Turbine linkedTurbine;
        public Generator(Turbine turbine, int voltage, int amperage)
        {
            V = voltage;
            A = amperage;
            powerOutput = V * A;
        }
        public void GetTurbineRotation()
        {
            rotPos = linkedTurbine.rotPos;
        }

        public void CompareRotPosPhase()
        {
            //compare rotation position to grid phase, if wriong, blow the generator up LOL give 2% probability of this damaging the turbines and releasing radiation
        }
        public void DisplayPowerOutput(double output)
        {


        }
    }
}
