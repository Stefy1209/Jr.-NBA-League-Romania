namespace Jr._NBA_League_Romania.Domain;

public class Game(Guid id, Guid idTeam1, Guid idTeam2, DateTime dateTime) : Entity<Guid>(id)
{
    public Guid IdTeam1 { get; } = idTeam1;
    public Guid IdTeam2 { get; } = idTeam2;
    public DateTime DateTime { get; } = dateTime;
}