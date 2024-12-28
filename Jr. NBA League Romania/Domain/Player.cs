namespace Jr._NBA_League_Romania.Domain;

public class Player(Guid id, string name, Guid idSchool, Guid teamId) : Student(id, name, idSchool)
{
    public Guid TeamId { get; } = teamId;
}