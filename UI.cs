namespace Sprotifly2;
using Spectre.Console;

public class UI
{
    private Database database;
    Users user;
    private Logic logic;
    int user_id;
    public UI()
    {
        database = new();
        logic = new();
        user = new();
    }
    public void StartingMenu()
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
                user_id = user.Id;
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
    public void ShowMyPlaylistsWithInfo(List<Playlist> playlists)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumns("Playlist", "Total Length", "Total Songs", "Date Added");
        foreach (Playlist item in playlists)
        {
            table.AddRow($"{item.Playlist_Name}", $"{item.Total_Length} min", $"{item.Total_Songs}", $"{item.Date_Added.ToShortDateString()}");
        }
        Console.Clear();
        AnsiConsole.Write(table);
        Console.Write("Choose playlist or back with [R]: ");
        string playlist = Console.ReadLine();
        if (playlist == "R" || playlist == "r")
        {
            return;
        }
        PlaylistMenu(playlist);
    }
    private void ShowMyPlaylists(List<Playlist> playlists)
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
    }
    private void ShowSongs(List<Song> songs)
    {
        var table = new Table();
        table.Border(TableBorder.Rounded);
        table.AddColumns("Id", "Song", "Length", "Genre", "Album");
        foreach (Song item in songs)
        {
            item.Minutes = item.CalculateSongLength(item.Song_length);
            table.AddRow($"{item.Id}", $"{item.Title}", $"{item.Minutes:F2} min", $"{item.Genre}", $"{item.Album}");
        }
        Console.Clear();
        AnsiConsole.Write(table);
        Console.Write("Press any key to continue...");
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
        Console.Write("Press any key to continue...");
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
        Console.Write("[1] My Playlists\n[2] Search\n[3] Create Playlist\n[4] Music\n[Q] Quit\n> ");
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
                    Console.Write("\nAdd song to playlist? [Y/N]: ");
                    string choice = Console.ReadLine();
                    if (choice == "Y" || choice == "y")
                    {
                        ShowMyPlaylists(database.GetPlaylistsForUser(user_id));
                        Console.Write("Choose playlist: ");
                        string playlist = Console.ReadLine();
                        List<Playlist> playlists = database.GetPlaylistsForUser(user_id);
                        int playlist_id = database.GetPlaylistId(playlist);
                        foreach (Playlist item in playlists)
                        {
                            Console.ReadKey();
                            if (item.Playlist_Name == playlist)
                            {
                                foreach (Song song in result)
                                {
                                    logic.AddSongToPlaylist(playlist_id, song.Id);
                                    Console.WriteLine($"{song.Title} added to {item.Playlist_Name}");
                                    Console.WriteLine("Press any key to continue...");
                                    Console.ReadKey();
                                }
                            }
                        }
                    }
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
                    ShowMyPlaylistsWithInfo(logic.GetPlaylists(user_id));
                    break;
                case "2":
                    SearchMenu();
                    break;
                case "3":
                    Console.Clear();
                    Console.Write("Can not contain å,ä,ö,Å,Ä,Ö. Write it on your own risk\nPlaylist name: ");
                    string playlist_name = Console.ReadLine();
                    DateTime date_added = DateTime.Now;
                    if (string.IsNullOrEmpty(playlist_name))
                    {
                        Console.WriteLine("Playlist name can't be empty");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return;
                    }
                    logic.CreatePlaylist(user_id, playlist_name, date_added);
                    Console.WriteLine("Playlist created");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "4":
                    MusicMenu();
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
    private void MusicMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine("[1] All songs\n[2] All artists\n[3] All albums\n[R] Back");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    ShowSongs(logic.AllSongs());
                    break;
                case "2":
                    ShowArtist(logic.AllArtists());
                    break;
                case "3":
                    ShowAlbum(logic.AllAlbums());
                    break;
                case "R":
                case "r":
                    return;

                default:
                    Console.WriteLine("Wrong input!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
    public void PlaylistMenu(string playlist)
    {
        while (true)
        {
            List<Song> songs = database.GetSongsFromPlaylist(playlist);
            Console.Clear();
            ShowSongs(songs);
            Console.WriteLine("\n[1] Update Name\n[2] Delete List\n[3] Delete Song from playlist\n[R] Return\n> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("New name: ");
                    string newname = Console.ReadLine();
                    logic.ChangePlaylistName(playlist, newname);
                    Console.WriteLine("Playlist name changed");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "2":
                    Console.Write("Are you sure you want to delete this playlist? [Y/N]: ");
                    string answer = Console.ReadLine();
                    if (answer == "Y" || answer == "y")
                    {
                        logic.DeletePlaylist(playlist);
                        Console.WriteLine("Playlist deleted");
                        Console.WriteLine("Press any key to continue...");
                        Console.ReadKey();
                        return;
                    }
                    break;
                case "3":
                    ShowSongs(database.GetSongsFromPlaylist(playlist));
                    Console.Write("\nChoose song id to remove: ");
                    int song = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                    int playlist_id = database.GetPlaylistId(playlist);
                    logic.DeleteSongFromPlaylist(playlist_id, song);
                    Console.WriteLine("Song removed");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
                case "R":
                case "r":
                    return;
                default:
                    Console.WriteLine("Wrong input!");
                    Console.WriteLine("Press any key to continue...");
                    Console.ReadKey();
                    break;
            }
        }
    }
}