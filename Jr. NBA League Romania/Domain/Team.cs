namespace Jr._NBA_League_Romania.Domain;

public class Team(Guid id, string name) : Entity<Guid>(id)
{
    public string Name { get; } = name;
}