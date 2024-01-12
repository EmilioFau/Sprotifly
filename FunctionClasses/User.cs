namespace Sprotifly2;
public class Users
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Password { get; set; }
    public int Country_id { get; set; }
    public bool Admin { get; set; }
    public string Username { get; set; }
    public int Id { get; set; }

    public override string ToString()
    {
        return $"Firstname: {Firstname}\nLastname: {Lastname}\nCountry: {Country_id}\nAdmin: {Admin}\nUsername: {Username}";
    }
}