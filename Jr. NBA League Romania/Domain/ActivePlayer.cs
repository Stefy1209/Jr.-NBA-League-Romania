namespace Jr._NBA_League_Romania.Domain;

public class ActivePlayer(Guid id, Guid playerId, Guid gameId, byte nrPointsScored, ActivePlayerType activePlayerType) : Entity<Guid>(id)
{
    public Guid PlayerId { get; } = playerId;
    public Guid GameId { get; } = gameId;
    public byte NrPointsScored { get; } = nrPointsScored;
    public ActivePlayerType ActivePlayerType { get; } = activePlayerType;
}