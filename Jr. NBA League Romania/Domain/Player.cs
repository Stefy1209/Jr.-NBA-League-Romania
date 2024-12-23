namespace Jr._NBA_League_Romania.Domain;

public class Player(Guid id, string name, string school, Guid teamId) : Student(id, name, school)
{
    public Guid TeamId { get; } = teamId;
}