namespace Sprotifly2;
using Spectre.Console;

public class UI
{
    private Database database;
    Users user;
    private Logic logic;
    public UI()
    {
        database = new();
        logic = new();
        user = new();
    }
    public void MainMenu()
    {
        ShowSongs();
        Console.WriteLine("Welcome to Sprotifly!");
        Console.WriteLine("Please choose an option:");
        Console.WriteLine("1. Login");
        Console.WriteLine("2. Register");
        Console.WriteLine("Q. Exit");
        string input = Console.ReadLine();
        switch (input)
        {
            case "1":
                LoginMenu();
                break;
            case "2":
                logic.Register();
                break;
            case "Q":
            case "q":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input, please try again.");
                MainMenu();
                break;
        }
    }
    public void LoginMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            if (database.ValidateLogin(username, password))
            {
                Console.WriteLine("Login successful");
                user = database.GetUser(username);
                List<Playlist> playlists = database.GetPlaylists(user.Id);
                Console.WriteLine(user.ToString());
                break;
            }
            else
            {
                Console.WriteLine("Wrong username or password!");
                Console.WriteLine("Press any key to try again...");
                Console.ReadKey();
            }
        }
    }
    private void ShowSongs()
    {
        List<Song> songs = database.GetSongs();
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumns("Song", "Length", "Genre", "Album");
        foreach (Song item in songs)
        {
            table.AddRow($"{item.Title}", $"{item.Minutes}", $"{item.Genre}", $"{item.Album}");
        }
        Console.Clear();
        AnsiConsole.Write(table);
    }
}