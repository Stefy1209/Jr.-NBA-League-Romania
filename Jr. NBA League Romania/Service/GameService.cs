using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;

namespace Jr._NBA_League_Romania.Service;

public class GameService
{
    private readonly GamesRepository _gamesRepository = new();

    public IEnumerable<Game> GetGames()
    {
        return _gamesRepository.FindAll();
    }

    public void SaveGame(Guid gameId, Guid team1Id, Guid team2Id, DateTime dateTime)
    {
        var game = new Game(gameId, team1Id, team2Id, dateTime);
        
        _gamesRepository.Save(game);
    }
}