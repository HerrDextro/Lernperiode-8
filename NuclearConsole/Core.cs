using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    class Core
    {
        readonly List<FuelRod> fuelRods = new List<FuelRod>();
        int numCtrlRods;
        int controlRodPosition; //0-10
        double heatOutput = 0; //in imaginary heat units, over 800 is meltdown, 10000 is explosion, under 100 is stalled. 500 is nominal.
        FuelPool fuelPool;
        string status;
        Secret secret;

        public Core(int totalFuelRods, int controlRods)
        {
            fuelPool = new FuelPool();
            secret = new Secret();
            InsertFuelRod(totalFuelRods);
            numCtrlRods = controlRods;
            controlRodPosition = 10; //fully inserted
            status = "Offline";

        }
        public void Update(double dt)
        {
            //update all rods
            foreach (var fuel in fuelRods)
                { fuel.Update(dt); }
        }

        //implement rest of these after UI is basically done
        public double CalculateHeatOutput()
        {
            double minutes = 0;
            while (controlRodPosition == 1 || controlRodPosition == 0 && fuelRods.Count > 0) //chernobyl mode lol
            {
                heatOutput *= Math.Pow(fuelRods.Count*100, minutes); //meltdown in >3 minutes with 10 fuel rods
            }
            //normal operation (REMINDER: negative feedback past critical point!!!!)
            heatOutput = (fuelRods.Count * 100) * (10 - controlRodPosition / 10); //more fuel rods and more retracted control rods = more heat //revisit later

            return heatOutput;
        }
        public string CalculateReactorStatus()
        {
            if (heatOutput > 800)
            {
                   status = "CRITICAL WARNING: MELTDOWN";
            }
            if (heatOutput > 10000)
            {
                status = "CRITICAL WARNING: EXPLOSION IMMINENT";
                secret.Explode();
            }
            if (heatOutput < 200 && heatOutput > 0)
            {
                status = "Reactor Stalled";
            }
            if (heatOutput >= 500 && heatOutput <= 800)
            {
                status = "Reactor Nominal";
            }
            if (heatOutput == 0)
            {
                status = "Offline";
            }

            return status;
        }
        public void MoveControlRods(int desiredPositions) //positions 0-10, 0 being fully retracted, 10 being fully inserted
        {
            while (controlRodPosition < desiredPositions) {
                Thread.Sleep(1000);
                controlRodPosition++;
            }
        }
        public void InsertFuelRod(int amount)
        {
            fuelRods.Add(new FuelRod());
        }
        public void RemoveFuelRod(List<FuelRod> fuelRods)
        {
            List<FuelRod> removedRods = new List<FuelRod>(fuelRods);
            foreach (FuelRod rod in fuelRods)
            {
                this.fuelRods.Remove(rod);
                removedRods.Add(rod);
            }
            fuelPool.StoreSpentFuelRods(removedRods);
        }
        public void DisplayReactorStatus()
        {
            if (status.Contains("CRITICAL WARNING"))
            {
                AnsiConsole.MarkupLine($"[bold red]{status}[/]");
                return;
            }
            AnsiConsole.MarkupLine($"[bold yellow]Reactor Status:[/] {status}");
        }
        public void DisplayReactorDiagram()
        {

        }
    }
}
