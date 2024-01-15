namespace Sprotifly2;
public class Users : Person
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Password { get; set; }
    public bool Admin { get; set; }
    public string Username { get; set; }

    public override string ToString()
    {
        return $"Firstname: {Firstname}\nLastname: {Lastname}\nCountry: {Country}\nAdmin: {Admin}\nUsername: {Username}";
    }
}