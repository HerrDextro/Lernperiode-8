using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole //test this later
{
    class Grid
    {
        private static Grid _gridsim;
        private Grid () { }

        public static Grid GetGridSimulation(int frequency, int V)
        {
            if (_gridsim == null)
            {
                _gridsim = new Grid(frequency, V);
            }
            return _gridsim;
        }

        int _frequency;
        int _V;
        public double phase1;
        public double phase2;
        public double phase3;
        public Grid(int frequency, int V)
        {
            _frequency = frequency;
            _V = V;
            ActivateGridSimulation();
        }

        private async Task ActivateGridSimulation()
        {
            int gridFrequency = _frequency;
            //simulate each phase here based on frequency
            while (true)
            {
                phase1 = GenerateSine(0);
                phase2 = GenerateSine(120);
                phase3 = GenerateSine(240);
            }
            
        }
        public double GenerateSine(double angleInDegrees)
        {
            double angleInRadians = (angleInDegrees * Math.PI) / 180;
            return Math.Sin(angleInRadians);

        }

    }
}
