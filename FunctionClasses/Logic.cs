namespace Sprotifly2;

public class Logic
{
    List<Country> countries;
    private Database database;
    public Logic()
    {
        database = new();
        countries = new();
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
        int countryId = int.Parse(country);
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
                database.NewUser(firstname, lastname, password, country, username, countryId);
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
    private void ShowCountries()
    {
        foreach (var country in countries)
        {
            Console.WriteLine(country.ToString());
        }
    }
}