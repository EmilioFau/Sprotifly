namespace Sprotifly2;
public class Logic
{
    private UI ui;
    private Database database;
    public Logic()
    {
        database = new();
    }
    public void TryFunctions()
    {

    }
    public void Register()
    {
        Console.Clear();
        Console.Write("Firstname: ");
        string firstname = Console.ReadLine();
        Console.Write("LastName: ");
        string lastname = Console.ReadLine();
        Console.Write("Country: ");
        string country = Console.ReadLine();
        int countryId = database.GetCountryId(country);
        Console.Write("Username: ");
        string username = Console.ReadLine();
        while (true)
        {
            Console.Write("New password: ");
            string password = Console.ReadLine();
            Console.Write("Repeat password: ");
            string password1 = Console.ReadLine();

            if (password == password1)
            {
                bool admin = false;
                database.NewUser(firstname, lastname, password, username, countryId, admin);
                Console.WriteLine("New account created\nPress any key to continue: ");
                Console.ReadKey();
                break;
            }
            else
            {
                Console.Clear();
                Console.Write("Passwords doesn't match!\n");
                Console.Write("Press any key to try again...");
                Console.ReadKey();
            }
        }
    }
    public List<Playlist> GetPlaylists(int user_id)
    {
        List<Playlist> playlists = database.GetPlaylistsWithInfo(user_id);
        return playlists;
    }
    public List<Song> SearchSong(string search)
    {
        List<Song> songs = database.SearchSong(search);
        return songs;
    }
    public List<Artist> SearchArtist(string search)
    {
        List<Artist> artists = database.SearchArtist(search);
        return artists;
    }
    public List<Album> SearchAlbum(string search)
    {
        List<Album> albums = database.SearchAlbum(search);
        return albums;
    }

    public void CreatePlaylist(int user_id, string playlist_name, DateTime date_added)
    {
        database.CreatePlaylist(user_id, playlist_name, date_added);
    }
    public void AddSongToPlaylist(int playlist_id, int song_id)
    {
        database.AddSongToPlaylist(playlist_id, song_id);
    }

    public List<Song> AllSongs()
    {
        List<Song> songs = database.GetSongs();
        return songs;
    }
    public List<Artist> AllArtists()
    {
        List<Artist> artists = database.GetArtists();
        return artists;
    }
    public List<Album> AllAlbums()
    {
        List<Album> albums = database.GetAlbums();
        return albums;
    }
    public void ChangePlaylistName(string oldName, string newName)
    {
        database.ChangePlaylistName(oldName, newName);
    }
    public void DeletePlaylist(string playlist_name)
    {
        database.DeletePlaylist(playlist_name);
    }
    public void DeleteSongFromPlaylist(int playlist_id, int song_id)
    {
        database.DeleteSongFromPlaylist(playlist_id, song_id);
    }
}