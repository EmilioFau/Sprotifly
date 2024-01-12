namespace Sprotifly2;
internal class Program
{
    private static void Main(string[] args)
    {

        UI ui = new();
        Logic logic = new();
        logic.TryFunctions();
        ui.MainMenu();

    }
}