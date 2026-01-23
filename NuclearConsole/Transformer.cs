using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    public class Transformer //swiss grid main is 380KV, secondary 220kv and generators output 10-25kv, lets take  20kV as standard gen output //all V measured in KV
    {
        int primaryCoil;
        int secondaryCoil;

        public Transformer()
        {
            primaryCoil = 50;
            secondaryCoil = 950;

        }
        public Transformer(int primaryCoilTurns, int secondaryCoilTurns) 
        {
            primaryCoil = primaryCoilTurns;
            secondaryCoil = secondaryCoilTurns;

        }

        public double TransformVoltage(double inputVoltage) //scenario: in (gen) 10V out 100V, primary 10 secondary 100   
        {
            return inputVoltage * (secondaryCoil / primaryCoil); // 380/19 = 20 //so secondary m19 primary m1, lets set primary at 50 windings so secondary at 950
        }


        public void DisplayPowerOutput(double output)
        {


        }
    }
}
