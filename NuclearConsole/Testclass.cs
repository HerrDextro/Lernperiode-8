using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Text;

namespace NuclearConsole
{
    static class Testclass
    {
        public static void TestMethod()
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




        }
    }
}

