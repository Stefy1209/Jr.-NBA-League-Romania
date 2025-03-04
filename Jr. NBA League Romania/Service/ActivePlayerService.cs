using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;

namespace Jr._NBA_League_Romania.Service;

public class ActivePlayerService
{
    private readonly ActivePlayersRepository _activePlayersRepository = new();

    public IEnumerable<ActivePlayer> GetActivePlayers()
    {
        return _activePlayersRepository.FindAll();
    }

    public void SaveActivePlayer(Guid id, Guid playerId, Guid gameId, byte nrPointsScored, ActivePlayerType activePlayerType)
    {
        var activePlayer = new ActivePlayer(id, playerId, gameId, nrPointsScored, activePlayerType);
        
        _activePlayersRepository.Save(activePlayer);
    }
}