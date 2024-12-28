namespace Jr._NBA_League_Romania.Domain;

public class Team(Guid id, string name) : Entity<Guid>(id)
{
    public string Name { get; } = name;

    public override bool Equals(object? obj)
    {
        var team = obj as Team;
        
        return team != null && Id == team.Id && Name == team.Name;
    }
    
    public override int GetHashCode()
    {
        return HashCode.Combine(Name, Id);
    }
}