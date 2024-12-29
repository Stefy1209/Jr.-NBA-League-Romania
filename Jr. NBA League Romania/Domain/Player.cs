namespace Jr._NBA_League_Romania.Domain;

public class Player(Guid id, string name, Guid schoolId, Guid teamId) : Student(id, name, schoolId)
{
    public Guid TeamId { get; } = teamId;
}