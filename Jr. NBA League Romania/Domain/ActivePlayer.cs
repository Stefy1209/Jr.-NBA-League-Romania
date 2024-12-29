namespace Jr._NBA_League_Romania.Domain;

public class ActivePlayer(Guid id, Guid playerId, Guid gameId, byte nrPointsScored, ActivePlayerType activePlayerType) : Entity<Guid>(id)
{
    public Guid PlayerId { get; } = playerId;
    public Guid GameId { get; } = gameId;
    public byte NrPointsScored { get; } = nrPointsScored;
    public ActivePlayerType ActivePlayerType { get; } = activePlayerType;

    public override bool Equals(object? obj)
    {
        var activePlayer = obj as ActivePlayer;
        
        return activePlayer != null && activePlayer.PlayerId == PlayerId && activePlayer.GameId == GameId && activePlayer.NrPointsScored == NrPointsScored && activePlayer.ActivePlayerType == ActivePlayerType;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, PlayerId, GameId, NrPointsScored, ActivePlayerType);
    }
}