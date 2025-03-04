namespace Jr._NBA_League_Romania.Utils;

public static class NameGenerator
{
    private static readonly Random Random = new();
    
    private static readonly string[] LastName = ["John", "Emma", "Michael", "Olivia", "James", "Sophia", "David", "Isabella", "Daniel", "Mia"];
    private static readonly string[] FirstName = ["Smith", "Johnson", "Brown", "Williams", "Jones", "Miller", "Davis", "Garcia", "Martinez", "Wilson"];

    public static string GenerateName()
    {
        var firstName = FirstName[Random.Next(FirstName.Length)];
        var lastName = LastName[Random.Next(LastName.Length)];
        return $"{firstName} {lastName}";
    }
}