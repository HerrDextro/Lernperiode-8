using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    public class MainCooling
    {
        public int flowRate; //sum of all pumps
        public int coolantTemp;
        public List<Pump> pumps;
        string status;
        public MainCooling(int numPumps, int pumpFlowRate)
        {
            pumps = new List<Pump>();
            for (int i = 0; i < numPumps; i++)
            {
                pumps.Add(new Pump("p" + (i+=1))); //names pumps p1 p2 etc (I hope)
                flowRate += pumpFlowRate;
            }
        }
        public void SetPumpSpeed(int pumpSpeed)
        {
            foreach (Pump pump in pumps)
            {
                pump.SetSpeed(pumpSpeed);
            }
        }
        public void CalculateFlowRate()
        {
            foreach (Pump pump in pumps)
            {
                flowRate += pump.flowRate;
            }
        }
        public void CalculateCoolantTemp(double heatOutput)
        {
            //simple model: coolant temp increases by 1 degree for every 1000 units of heat output per minute, decreases by 5 degrees per minute due to ambient cooling
            double tempIncrease = heatOutput / 100;
            coolantTemp += (int)tempIncrease;
            coolantTemp -= (pumps.Count * flowRate / 50); //ok for now, try get more realism later
            if (coolantTemp < 20) //ambient temp floor
            {
                coolantTemp = 20;
            }
        }
        public void DisplayCoolingStatus()
        {
            AnsiConsole.MarkupLine($"[bold cyan]Cooling System Status:[/] {status}");
        }
    }
}
