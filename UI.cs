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
    public void StartingMenu()
    {
        {
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
                    break;
            }
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
    public void ShowMyPlaylists(List<Playlist> playlists)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumns("Playlist", "Date Added");
        foreach (Playlist item in playlists)
        {
            table.AddRow($"{item.Playlist_Name}", $"{item.Date_Added.ToShortDateString()}");
        }
        Console.Clear();
        AnsiConsole.Write(table);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private void ShowSongs(List<Song> songs)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumns("Song", "Length", "Genre", "Album");
        foreach (Song item in songs)
        {
            item.Minutes = item.CalculateSongLength(item.Song_length);
            table.AddRow($"{item.Title}", $"{item.Minutes:F2}", $"{item.Genre}", $"{item.Album}");
        }
        Console.Clear();
        AnsiConsole.Write(table);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private void ShowAlbum(List<Album> albums)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumns("Artist", "Album", "Release Date");
        string previousArtist = null;
        foreach (Album item in albums)
        {
            if (item.Artist != previousArtist)
            {
                table.AddRow($"{item.Artist}", $"{item.Title}", $"{item.Release_Date.ToShortDateString()}");
                previousArtist = item.Artist;
            }
            else
            {
                table.AddRow("", $"{item.Title}", $"{item.Release_Date.ToShortDateString()}");
            }
        }
        Console.Clear();
        AnsiConsole.Write(table);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private void ShowArtist(List<Artist> artists)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumns("Artist", "Country", "Albums");
        string previousArtist = null;
        string country = null;
        foreach (Artist item in artists)
        {
            if (item.Name != previousArtist && item.Country != country)
            {
                table.AddRow($"{item.Name}", $"{item.Country}", $"{item.Album}");
                previousArtist = item.Name;
            }
            else
            {
                table.AddRow("", "", $"{item.Album}");
            }
        }
        Console.Clear();
        AnsiConsole.Write(table);
        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
    private void ShowMenu()
    {
        Console.Clear();
        Console.Write("[1] My Playlists\n[2] Search\n[3] Create Playlist\n[Q] Quit\n> ");
    }
    public void SearchMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("Search for:");
            Console.WriteLine("[1] Song\n[2] Artist\n[3] Album\n[R] Return");
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    Console.Clear();
                    Console.Write("Search for song: ");
                    string search = Console.ReadLine();
                    List<Song> result = logic.SearchSong(search);
                    if (result.Count == 0)
                    {
                        Console.WriteLine("No results found");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    ShowSongs(result);
                    break;
                case "2":
                    Console.Clear();
                    Console.Write("Search for artist: ");
                    string searchArtist = Console.ReadLine();
                    List<Artist> resultArtist = logic.SearchArtist(searchArtist);
                    if (resultArtist.Count == 0)
                    {
                        Console.WriteLine("No results found");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    ShowArtist(resultArtist);
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Search for album: ");
                    string searchAlbum = Console.ReadLine();
                    List<Album> resultAlbum = logic.SearchAlbum(searchAlbum);
                    if (resultAlbum.Count == 0)
                    {
                        Console.WriteLine("No results found");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        break;
                    }
                    ShowAlbum(resultAlbum);
                    break;
                case "R":
                case "r":
                    return;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }
        }
    }
    public void Menu()
    {

        while (true)
        {
            ShowMenu();
            string input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    ShowMyPlaylists(logic.GetPlaylists(user.Id));
                    break;
                case "2":
                    SearchMenu();
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Can not contain å,ä,ö,Å,Ä,Ö. Write it on your own risk\nPlaylist name: ");
                    string playlist_name = Console.ReadLine();
                    DateTime date_added = DateTime.Now;
                    logic.CreatePlaylist(user.Id, playlist_name, date_added);
                    Console.WriteLine("Playlist created");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "Q":
                case "q":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }
        }
    }
}