
---
Spectre.Console Tutorial – Full Demo
---
This tutorial shows how to use **Spectre.Console** to build interactive console apps in C#. We cover layouts, panels, tables, charts, progress bars, spinners, and dialogs.


## 1. Setup

Install the **Spectre.Console** NuGet package:

```bash
dotnet add package Spectre.Console
```

Or via Visual Studio Package Manager:

```powershell
Install-Package Spectre.Console
```

---

## 2. Program Overview

Here’s the complete demo program we’ll use:

```csharp
using Spectre.Console;
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        // 1. Layout
        var layout = new Layout("root")
            .SplitRows(
                new Layout("Top").SplitColumns(
                    new Layout("Panel1"),
                    new Layout("Panel2")
                ),
                new Layout("Bottom")
            );

        // 2. Panel 1 – Table
        var table = new Table()
            .AddColumn("Name")
            .AddColumn("Status")
            .AddRow("Reactor", "[green]Nominal[/]")
            .AddRow("Turbine", "[yellow]Idle[/]")
            .AddRow("Grid", "[green]Online[/]");

        layout["Panel1"].Update(new Panel(table).Header("System Overview"));

        // 3. Panel 2 – Bar Chart
        var barChart = new BarChart()
            .Width(25)
            .Label("[green]Power[/]")
            .AddItem("Gen", 80, Color.Green)
            .AddItem("Grid", 50, Color.Blue)
            .AddItem("Heat", 65, Color.Red);

        layout["Panel2"].Update(new Panel(barChart).Header("Metrics"));

        // 4. Bottom Panel – Log / Info
        var logPanel = new Panel(new Markup("[grey]System log goes here[/]"))
            .Header("Logs / Info");
        layout["Bottom"].Update(logPanel);

        // Render layout
        AnsiConsole.Clear();
        AnsiConsole.Write(layout);

        // 5. Progress Bar Example
        AnsiConsole.WriteLine();
        AnsiConsole.MarkupLine("[bold]Running Startup Sequence...[/]");
        AnsiConsole.Progress()
            .Start(ctx =>
            {
                var task1 = ctx.AddTask("Initializing Core...", maxValue: 100);
                var task2 = ctx.AddTask("Spinning Turbine...", maxValue: 100);
                while (!ctx.IsFinished)
                {
                    task1.Increment(2.5);
                    task2.Increment(1.5);
                    Thread.Sleep(50);
                }
            });

        // 6. Spinner / Status
        AnsiConsole.MarkupLine("\n[bold]Connecting to Grid...[/]");
        AnsiConsole.Status()
            .Spinner(Spinner.Known.Dots)
            .Start("Please wait...", ctx =>
            {
                Thread.Sleep(2000);
            });

        // 7. Dialog / Selection Prompt
        var choice = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("Choose an action:")
                .AddChoices(new[] { "Start Reactor", "Shutdown Reactor", "Exit" })
        );

        AnsiConsole.MarkupLine($"You selected: [yellow]{choice}[/]");
    }
}
```

---

## 3. Walkthrough

### 3.1 Layouts

`Layout` allows you to split the console into rows and columns.

```csharp
var layout = new Layout("root")
    .SplitRows(
        new Layout("Top").SplitColumns(
            new Layout("Panel1"),
            new Layout("Panel2")
        ),
        new Layout("Bottom")
    );
```

* `SplitRows` divides the console vertically.
* `SplitColumns` divides a row horizontally.
* You can update each layout section with any **IRenderable** (Panel, Table, Chart, etc.).

---

### 3.2 Panels and Tables

Panels are containers that can have borders and headers.

```csharp
var table = new Table()
    .AddColumn("Name")
    .AddColumn("Status")
    .AddRow("Reactor", "[green]Nominal[/]")
    .AddRow("Turbine", "[yellow]Idle[/]")
    .AddRow("Grid", "[green]Online[/]");

layout["Panel1"].Update(new Panel(table).Header("System Overview"));
```

* `[green]Nominal[/]` uses **markup** for colors.
* `Panel` wraps a Table and adds a border + header.

---

### 3.3 Bar Charts

Bar charts are useful for metrics:

```csharp
var barChart = new BarChart()
    .Width(25)
    .Label("[green]Power[/]")
    .AddItem("Gen", 80, Color.Green)
    .AddItem("Grid", 50, Color.Blue)
    .AddItem("Heat", 65, Color.Red);

layout["Panel2"].Update(new Panel(barChart).Header("Metrics"));
```

* `AddItem(label, value, color)` creates a single bar.
* The height/value of bars is proportional to the numeric value.

---

### 3.4 Progress Bars

Use `AnsiConsole.Progress()` for tasks with progress:

```csharp
AnsiConsole.Progress()
    .Start(ctx =>
    {
        var task1 = ctx.AddTask("Initializing Core...", maxValue: 100);
        var task2 = ctx.AddTask("Spinning Turbine...", maxValue: 100);
        while (!ctx.IsFinished)
        {
            task1.Increment(2.5);
            task2.Increment(1.5);
            Thread.Sleep(50);
        }
    });
```

* Multiple tasks can run at once.
* `Increment` updates the progress.

---

### 3.5 Spinner / Status

Show a loading spinner for async tasks:

```csharp
AnsiConsole.Status()
    .Spinner(Spinner.Known.Dots)
    .Start("Please wait...", ctx =>
    {
        Thread.Sleep(2000);
    });
```

* `Spinner.Known.Dots` is one of many built-in spinner styles.

---

### 3.6 Dialogs and Selection Prompts

Interactive input from the user:

```csharp
var choice = AnsiConsole.Prompt(
    new SelectionPrompt<string>()
        .Title("Choose an action:")
        .AddChoices(new[] { "Start Reactor", "Shutdown Reactor", "Exit" })
);
```

* Users can navigate using arrow keys and select an option.
* Output can be displayed with markup:

  ```csharp
  AnsiConsole.MarkupLine($"You selected: [yellow]{choice}[/]");
  ```

---

## 4. Notes

* All UI elements implement **`IRenderable`**.
* Panels, Tables, Charts, and Rows can be nested for complex dashboards.
* `AnsiConsole.Clear()` is often used to refresh the screen.
* You can combine live updates (`LiveDisplay`) for animated dashboards.

