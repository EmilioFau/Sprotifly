// namespace Sprotifly2;
// public class DataProvider
// {
//     public List<Song> Songs { get; set; }
//     public List<Artist> Artists { get; set; }
//     public List<Album> Albums { get; set; }
//     public List<Genre> Genres { get; set; }
//     public List<Country> Countries { get; set; }
//     public List<Label> Labels { get; set; }
//     public List<Users> Users { get; set; }
//     public List<Playlist> Playlists { get; set; }


//     public DataProvider()
//     {
//         Songs = new List<Song>();
//         Artists = new List<Artist>();
//         Albums = new List<Album>();
//         Genres = new List<Genre>();
//         Countries = new List<Country>();
//         Labels = new List<Label>();
//         Users = new List<Users>();
//         Playlists = new List<Playlist>();
//     }

//     public List<Song> GetSongs()
//     {
//         Song song = new()
//         {
//             Id = 1,
//             Title = "The Leper Affinity",
//             Song_length = 613,
//             Genre = 12,
//             Album = 1
//         };
//         Song song1 = new()
//         {
//             Id = 10,
//             Title = "Master of Puppets",
//             Song_length = 501,
//             Genre = 2,
//             Album = 2
//         };
//         Song song2 = new()
//         {
//             Id = 44,
//             Title = "Bohemian Rhapsody",
//             Song_length = 360,
//             Genre = 1,
//             Album = 4
//         };
//         Songs.Add(song);
//         Songs.Add(song1);
//         Songs.Add(song2);
//         return Songs;
//     }

//     public List<Artist> GetArtists()
//     {
//         Artist artist = new()
//         {
//             Id = 1,
//             Country_Id = 7,
//             Name = "Opeth"
//         };
//         Artist artist1 = new()
//         {
//             Id = 2,
//             Country_Id = 1,
//             Name = "Metallica"
//         };
//         Artist artist2 = new()
//         {
//             Id = 4,
//             Country_Id = 2,
//             Name = "Queen"
//         };
//         Artists.Add(artist);
//         Artists.Add(artist1);
//         Artists.Add(artist2);
//         return Artists;
//     }

//     public List<Album> GetAlbums()
//     {
//         Album album = new()
//         {
//             Id = 1,
//             Title = "Blackwater Park",
//             Label_Id = 1002,
//             Release_Date = new DateOnly(2001, 2, 27)
//         };
//         Album album1 = new()
//         {
//             Id = 2,
//             Title = "Master of Puppets",
//             Label_Id = 1003,
//             Release_Date = new DateOnly(1986, 3, 3)
//         };
//         Album album2 = new()
//         {
//             Id = 4,
//             Title = "A Night at the Opera",
//             Label_Id = 5,
//             Release_Date = new DateOnly(1975, 11, 21)
//         };
//         Albums.Add(album);
//         Albums.Add(album1);
//         Albums.Add(album2);
//         return Albums;
//     }

//     public List<Genre> GetGenres()
//     {
//         Genre genre = new()
//         {
//             Id = 1,
//             Genre_Type = "Rock"
//         };
//         Genre genre1 = new()
//         {
//             Id = 2,
//             Genre_Type = "Metal"
//         };
//         Genre genre2 = new()
//         {
//             Id = 12,
//             Genre_Type = "Progressive Metal"
//         };
//         Genres.Add(genre);
//         Genres.Add(genre1);
//         Genres.Add(genre2);
//         return Genres;
//     }

//     public List<Country> GetCountries()
//     {
//         Country country = new()
//         {
//             Id = 1,
//             Country_Name = "USA"
//         };
//         Country country1 = new()
//         {
//             Id = 2,
//             Country_Name = "UK"
//         };
//         Country country2 = new()
//         {
//             Id = 7,
//             Country_Name = "Sweden"
//         };
//         Countries.Add(country);
//         Countries.Add(country1);
//         Countries.Add(country2);
//         return Countries;
//     }
//     public List<Label> GetLabels()
//     {
//         Label label = new()
//         {
//             Id = 5,
//             Label_Name = "EMI"
//         };
//         Label label1 = new()
//         {
//             Id = 1002,
//             Label_Name = "Music for Nations"
//         };
//         Label label2 = new()
//         {
//             Id = 1003,
//             Label_Name = "Elektra"
//         };
//         Labels.Add(label);
//         Labels.Add(label1);
//         Labels.Add(label2);
//         return Labels;
//     }
//     public Users GetUser(string username)
//     {
//         Users user = new()
//         {
//             Id = 1,
//             Firstname = "John",
//             Lastname = "Doe",
//             Password = "1234",
//             Country_id = 1,
//             Admin = true,
//             Username = username
//         };
//         return user;
//     }
//     public List<Playlist> GetPlaylists(int user_id)
//     {
//         Playlist playlist = new()
//         {
//             Id = 1,
//             Playlist_Name = "My Playlist",
//             Song_Id = 1,
//             User_Id = user_id,
//             Date_Added = new DateOnly(2018, 3, 17)
//         };
//         Playlist playlist1 = new()
//         {
//             Id = 2,
//             Playlist_Name = "My Playlist1",
//             Song_Id = 10,
//             User_Id = user_id,
//             Date_Added = new DateOnly(2023, 10, 10)
//         };
//         Playlists.Add(playlist);
//         Playlists.Add(playlist1);
//         return Playlists;
//     }
// }
