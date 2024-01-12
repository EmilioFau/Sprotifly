namespace Sprotifly2;
public class Song
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int Song_length { get; set; }
    public string Genre { get; set; }
    public string Album { get; set; }

    public override string ToString()
    {
        return $"id:{Id} title:{Title} längd:{Song_length} genre:{Genre} album:{Album}";
    }

}