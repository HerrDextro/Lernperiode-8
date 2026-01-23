using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    static class Testclass
    {
        public static void TestMethod1()
        {

            char mychar = '▀';
            char[] mycharArray = { '▇', '▇', '▇', '▇' };
            char[] mycharArray2 = { '▆', '▆', '▆', '▆' };
            Console.WriteLine(mychar);

            foreach (char c in mycharArray2)
                Console.Write(c + " ");


            foreach (char c in mycharArray)
                Console.Write(c + " ");


            int width = 60;
            int height = 15;

            var values = new List<int>();
            var rand = new Random();

            AnsiConsole.Live(new Spectre.Console.Panel("")).Start(ctx =>
            {
                for (int i = 0; i < 100; i++)
                {
                    if (values.Count >= width)
                        values.RemoveAt(0);

                    values.Add(rand.Next(0, 100)); // placeholder fake

                    var canvas = new Canvas(width, height);

                    // clear
                    for (int x = 0; x < width; x++)
                        for (int y = 0; y < height; y++)
                            canvas.SetPixel(x, y, Color.Black);

                    // draw graph
                    for (int x = 0; x < values.Count; x++)
                    {
                        int v = values[x];
                        int y = height - 1 - (v * (height - 1) / 100);

                        canvas.SetPixel(x, y, Color.Green);
                    }

                    var panel = new Spectre.Console.Panel(canvas)
                        .Header("Reactor Power")
                        .Border(BoxBorder.Rounded);

                    ctx.UpdateTarget(panel);

                    Thread.Sleep(200);
                }
            });
            Thread.Sleep(2000);


            var chart = new BarChart()
            .Width(60)
            .Label("[green]Core Heat Distribution[/]")
            .AddItem("Sector A", 23, Color.Green)
            .AddItem("Sector B", 57, Color.Yellow)
            .AddItem("Sector C", 89, Color.Red);

            AnsiConsole.Write(chart);

            Thread.Sleep(2000);

            var layout = new Layout("Root")
            .SplitColumns(
                new Layout("Left"),
                new Layout("Right").SplitRows(
                    new Layout("Top"),
                    new Layout("Bottom")
                )
            );

            chart
            .Width(60)
            .Label("Reactor Power History");

            chart.AddItem("Now", 73, Color.Green);
            AnsiConsole.Write(chart);





        }

        public static void TestMethod2()
        {
            //first the core overview:
            var texture = File.ReadAllText(@"C:\\Users\\Neo\\source\\repos\\NuclearConsole\\NuclearConsole\\texture\\core.txt");
            Console.Write(texture);
            Console.WriteLine("");

            //COOLING SYSTEM    
            var coolingOverviewTable = new Table()
                .AddColumn("Pump")
                .AddColumn("Status")
                .AddColumn("Flow")
                .AddColumn("Temp")

                .AddRow("P1", "[green]OK[/]", "100", "280")
                .AddRow("P2", "[green]OK[/]", "70", "200");
            AnsiConsole.Write(coolingOverviewTable);

            //Turbine and Generator/Grid and power (MW, kV, Hz)
            string electricalStats = ("RPM:        3000\r\nTorque:     12345\r\nPower:      980 MW\r\nVoltage:    20.1 kV\r\nFrequency:  50.00 Hz\r\n");
            var panel = new Panel(electricalStats) //per default a square border, can make round too
                .Header("Electrical Information"); //accepts header position, border type/color/thickness, order padding
            AnsiConsole.Write(panel);

            //Grid load graph(history)



            //maintenace schedule (MUST IMPLEMENT somewhere, its too cool to skip)
            var calendar = new Calendar(2025, 1)
                .AddCalendarEvent(2025, 1, 15)
                .AddCalendarEvent(2025, 1, 20)
                .HighlightStyle(Style.Parse("yellow bold"));

            AnsiConsole.Write(calendar);
        }

        public static void TestMethod3()
        {
            //CORE
            Table coreTable = new Table();
            coreTable.Border = TableBorder.None;

            // Suppose 11 columns
            for (int c = 0; c < 11; c++)
                coreTable.AddColumn(new TableColumn("").Centered());

            for (int y = 0; y < 11; y++)
            {
                var row = new List<string>();

                for (int x = 0; x < 11; x++)
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

            AnsiConsole.Write(new Panel(coreTable).Header("Core"));

            //FOR MAPPIGN TO CORE: MAKE CORE EXPOSE "CoreCell" or smt, as its own object with fuelrod/controlrod and temperature, render color based on temp

            //Power draw history
            Queue<double> history = new Queue<double>();
            
            history.Enqueue(50);
            history.Enqueue(60);
            history.Enqueue(80);
            history.Enqueue(90);
            history.Enqueue(100);

            var chart = new BarChart()
                .Width(60)
                .Label("Load History");

            foreach (var v in history)
            {
                chart.AddItem("", (float)v, Color.Green);
            }
            AnsiConsole.Write(chart);
                

        }


    }
}

