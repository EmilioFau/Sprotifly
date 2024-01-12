namespace Sprotifly2;
public class Playlist
{
    public int Id { get; set; }
    public string Playlist_Name { get; set; }
    public int Song_Id { get; set; }
    public int User_Id { get; set; }
    public DateOnly Date_Added { get; set; }
}