namespace Jr._NBA_League_Romania.Domain;

public class Player(Guid id, string name, Guid schoolId, Guid teamId) : Student(id, name, schoolId)
{
    public Guid TeamId { get; } = teamId;

    public override bool Equals(object? obj)
    {
        var player = obj as Player;
        
        return player != null && Id == player.Id && Name == player.Name && SchoolId == player.SchoolId && TeamId == player.TeamId;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, SchoolId, TeamId);
    }
}