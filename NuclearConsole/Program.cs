namespace NuclearConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("Nuclear Console Application Running on .NET 10.0 with C# 14.0");
            Console console = new Console();
            console.ConfigReactor();
        }
    }
}