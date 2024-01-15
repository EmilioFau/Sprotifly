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
    public List<Artist> SearchArtist(string artist)
    {
        connection.Open();
        string sqlquery = "SELECT artist.id, artist.name, artist.country_id, country.country, Album.title as Album FROM Artist INNER JOIN Country on Country.id = Artist.country_id INNER JOIN Album on Album.artist_id = Artist.id WHERE artist.name = @artist";
        IEnumerable<Artist> result = connection.Query<Artist>(sqlquery, new { artist });
        List<Artist> artists = result.ToList();
        connection.Close();
        return artists;
    }
    public List<Album> SearchAlbum(string album)
    {
        connection.Open();
        string sqlquery = "SELECT album.id, album.title, artist.name as artist, Label.name as label, album.release_date FROM Album INNER JOIN Artist on Artist.id = Album.artist_id INNER JOIN Label on Label.id = Album.id WHERE album.title = @album";
        IEnumerable<Album> result = connection.Query<Album>(sqlquery, new { album });
        List<Album> albums = result.ToList();
        connection.Close();
        return albums;
    }
    public List<Album> GetAlbums()
    {
        connection.Open();
        string sqlquery = "SELECT album.id, album.title, artist.name as artist, Label.name as label, album.release_date FROM Album INNER JOIN Artist on Artist.id = Album.artist_id INNER JOIN Label on Label.id = Album.id ORDER BY artist.name";
        IEnumerable<Album> result = connection.Query<Album>(sqlquery);
        List<Album> albums = result.ToList();
        connection.Close();
        return albums;
    }
    public List<Song> SearchSong(string song)
    {
        connection.Open();
        string sqlquery = "SELECT song.id, song.title ,song.song_length, album.title as album, genre.genre FROM Song INNER JOIN Album on album.id = song.album_id INNER JOIN Genre on genre.id = song.genre_id WHERE song.title = @song";
        IEnumerable<Song> result = connection.Query<Song>(sqlquery, new { song });
        List<Song> songs = result.ToList();
        connection.Close();
        return songs;
    }
    public List<Country> GetCountries()
    {
        connection.Open();
        List<Country> countries = connection.Query<Country>("SELECT * FROM Country").ToList();
        connection.Close();
        return countries;
    }
    public int GetCountryId(string country)
    {
        connection.Open();
        IEnumerable<Country> result = connection.Query<Country>("SELECT id FROM Country WHERE country = @country", new { country });
        List<Country> countries = result.ToList();
        connection.Close();
        return countries[0].Id;
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
    public void CreatePlaylist(int user_id, string playlist_name, DateTime date_added)
    {
        connection.Open();
        string sqlquery = "INSERT INTO Playlist (user_id, playlist_name, date_added) VALUES (@user_id, @playlist_name, @date_added)";
        connection.Execute(sqlquery, new { user_id, playlist_name, date_added });
        connection.Close();
    }

    public void NewUser(string firstname, string lastname, string password, string username, int country_id, bool admin)
    {
        connection.Open();
        string sqlquery = "INSERT INTO Users (firstname, lastname, password, country_id, username, admin) VALUES (@firstname, @lastname, @password, @country_id, @username, @admin)";
        connection.Execute(sqlquery, new { firstname, lastname, password, country_id, username, admin });
        connection.Close();
    }

}