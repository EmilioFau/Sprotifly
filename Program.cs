namespace Sprotifly2;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.Clear();
        UI ui = new();
        Logic logic = new();
        ui.StartingMenu();
        ui.Menu();
    }
}