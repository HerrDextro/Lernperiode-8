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
            // Calm and steady
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Dots)
                .Start("Grinding beans...", ctx =>
                {
                    Thread.Sleep(2000);
                });

            // Energetic
            AnsiConsole.Status()
                .Spinner(Spinner.Known.Star)
                .SpinnerStyle(Style.Parse("yellow"))
                .Start("Brewing coffee...", ctx =>
                {
                    Thread.Sleep(2000);
                });

            AnsiConsole.MarkupLine("[green]Done![/]");
        }
    }
}
