namespace Sprotifly2;
using Dapper;
using System.Data;
using System.Data.SqlClient;
public class Database
{
    IDbConnection connection;
    public Database()
    {
        connection = new SqlConnection("Server=localhost,1433;User=sa;Password=apA123!#!;Database=Sprotifly;");
    }
    public List<Song> GetSongs()
    {
        connection.Open();
        List<Song> songs = connection.Query<Song>("SELECT song.id, song.title ,song.song_length, album.title as album, genre.genre FROM Song INNER JOIN Album on album.id = song.album_id INNER JOIN Genre on genre.id = song.genre_id").ToList();
        connection.Close();
        return songs;
    }
    public List<Artist> GetArtists()
    {
        connection.Open();
        List<Artist> artists = connection.Query<Artist>("SELECT * FROM Artists").ToList();
        connection.Close();
        return artists;
    }
    public List<Album> GetAlbums()
    {
        connection.Open();
        string sqlquery = "SELECT a.name as artist_or_band, ab.title as albumtitle FROM Artist AS a INNER JOIN Album_to_Artist AS ata on ata.artist_id = a.id INNER JOIN Album ab on ab.id = ata.album_id;";
        List<Album> albums = connection.Query<Album>(sqlquery).ToList();
        connection.Close();
        return albums;
    }
    public List<Genre> GetGenres()
    {
        connection.Open();
        List<Genre> genres = connection.Query<Genre>("SELECT * FROM Genres").ToList();
        connection.Close();
        return genres;
    }
    public List<Country> MatchCountry(string Country_id)
    {
        connection.Open();
        IEnumerable<Country> result = connection.Query<Country>("SELECT * FROM Country WHERE id = @country_id", new { Country_id });
        List<Country> countries = result.ToList();
        connection.Close();
        return countries;
    }
    public List<Label> GetLabels()
    {
        connection.Open();
        List<Label> labels = connection.Query<Label>("SELECT * FROM Labels").ToList();
        connection.Close();
        return labels;
    }
    public Users GetUser(string username)
    {
        connection.Open();
        Users user = connection.QueryFirstOrDefault<Users>("SELECT * FROM Users WHERE username = @username", new { username });
        connection.Close();
        return user;

    }
    public List<Playlist> GetPlaylists(int user_id)
    {
        connection.Open();
        List<Playlist> playlists = connection.Query<Playlist>("SELECT * FROM Playlist WHERE user_id = @user_id", new { user_id }).ToList();
        connection.Close();
        return playlists;
    }

    public bool ValidateLogin(string username, string password)
    {
        string sqlquery = "SELECT username, password FROM Users WHERE username = @username AND password = @password";
        var user = connection.QueryFirstOrDefault<Users>(sqlquery, new { username, password });
        return user != null;
    }
    // public void NewPlaylist(string playlist_name, int user_id)
    // {
    //     connection.Open();
    //     DateTime today = DateTime.Now;
    //     DateOnly dateOnly = today.Date;
    //     Console.WriteLine($"Dagens datum med månad och år: {dateOnly:yyyy-MM-dd}");
    //     string sqlquery = "INSERT INTO Playlist (user_id, date_added, playlist_name ) VALUES (@playlist_name, @user_id, @date_added)";
    //     connection.Execute(sqlquery, new { playlist_name, user_id, dateOnly });
    //     connection.Close();
    // }

    public void NewUser(string firstname, string lastname, string password, string country, string username, int country_id)
    {
        connection.Open();
        string sqlquery = "INSERT INTO Users (firstname, lastname, password, country, username) VALUES (@firstname, @lastname, @password, @country_id, @username)";
        connection.Execute(sqlquery, new { firstname, lastname, password, country_id, username });
        connection.Close();
    }

}