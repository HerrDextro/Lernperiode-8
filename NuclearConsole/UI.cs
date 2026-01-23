using System;
using System.Collections.Generic;
using System.Text;
using Spectre.Console;

namespace NuclearConsole
{
    class UI
    {
        //UI must do
        //plant.InsertControlRods(10);
        //plant.SetTargetPower(800_000_000);
        //eventually

        Plant plant;
        Core reactorCore;
        MainCooling mainCoolingSystem;
        SecondaryCooling secondaryCoolingSystem;
        Turbine turbine;
        Generator generator;
        Grid grid;

        public UI(Plant plant, Core core, MainCooling mainCooling, SecondaryCooling secondaryCooling, Turbine turbine, Generator generator, Grid grid)
        {
            this.plant = plant;
            reactorCore = core;
            mainCoolingSystem = mainCooling;
            secondaryCoolingSystem = secondaryCooling;
            this.turbine = turbine;
            this.generator = generator;
            this.grid = grid;

        }
        Layout BuildLayout()
        {
            // Root layout splits rows
            var layout = new Layout("root")
                .SplitRows(
                    new Layout("Top").SplitColumns(
                        new Layout("Core"),
                        new Layout("Cooling"),
                        new Layout("Electrical")
                    ),
                    new Layout("Bottom").SplitColumns(
                        new Layout("Turbine"),
                        new Layout("Graph"),
                        new Layout("Log")
                    ),
                    new Layout("Commands")
                );

            return layout;
        }
        public void Render()
        {
            var layout = BuildLayout();

            layout["Core"].Update(RenderCore()); //does not get its own container, fix this
            layout["Cooling"].Update(RenderMainCooling());
            /*layout["Electrical"].Update(RenderElectrical());
            layout["Graph"].Update(RenderGraph());
            layout["Log"].Update(RenderLog());
            layout["Commands"].Update(RenderCommands());*/

            AnsiConsole.Clear();
            AnsiConsole.Write(layout);
        }

        Table RenderCore()
        {
            //CORE
            Table coreTable = new Table();
            coreTable.Border = TableBorder.None;

            // Suppose 5 columns
            for (int c = 0; c < 5; c++)
                coreTable.AddColumn(new TableColumn("").Centered());

            for (int y = 0; y < 5; y++)
            {
                var row = new List<string>();

                for (int x = 0; x < 5; x++)
                {
                    // Example fake logic
                    bool isFuel = (x + y) % 2 == 0;

                    if (isFuel)
                        row.Add("[red]██[/]");
                    else
                        row.Add("[grey]░░[/]");
                }
                coreTable.AddRow(row.ToArray());
            }

            //AnsiConsole.Write(new Panel(coreTable).Header("Core"));

            //FOR MAPPIGN TO CORE: MAKE CORE EXPOSE "CoreCell" or smt, as its own object with fuelrod/controlrod and temperature, render color based on temp
            return coreTable;
        }

        Panel RenderMainCooling()
        {
            var table = new Table();
            table.AddColumn("Pump");
            table.AddColumn("Status");
            table.AddColumn("Flow");
            table.AddColumn("Temp");

            foreach (var pump in plant.mainCooling.pumps)
            {
                string status;
                if(pump.pumpStatus == "Online")
                {
                    status = "[green]Online[/]";
                }
                else
                {
                    status = "[red]Offline[/]";
                }
                table.AddRow(pump.identifier, status, pump.flowRate.ToString(), mainCoolingSystem.coolantTemp.ToString());
            }

            return new Panel(table).Header("Main Cooling");
        }

    }
}
