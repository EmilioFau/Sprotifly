namespace Sprotifly2;
public class Country
{
    public int Id { get; set; }
    public string Country_Name { get; set; }

    public override string ToString()
    {
        return $"{Id} {Country_Name}";
    }
}