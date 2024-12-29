namespace Jr._NBA_League_Romania.Domain;

public class Game(Guid id, Guid idTeam1, Guid idTeam2, DateTime dateTime) : Entity<Guid>(id)
{
    public Guid IdTeam1 { get; } = idTeam1;
    public Guid IdTeam2 { get; } = idTeam2;
    public DateTime DateTime { get; } = dateTime;

    public override bool Equals(object? obj)
    {
        var game = obj as Game;
        
        return game != null 
               && Id == game.Id 
               && IdTeam1 == game.IdTeam1 
               && IdTeam2 == game.IdTeam2 
               && Math.Abs(DateTime.Subtract(game.DateTime).Microseconds) < 1;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, IdTeam1, IdTeam2, DateTime);
    }
}