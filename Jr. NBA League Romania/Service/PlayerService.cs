using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;
using Jr._NBA_League_Romania.Validator;

namespace Jr._NBA_League_Romania.Service;

public class PlayerService
{
    private readonly PlayersRepository _playersRepository = new();
    private readonly PlayerValidator _playerValidator = new();

    public IEnumerable<Player> GetPlayers()
    {
        return _playersRepository.FindAll();
    }

    public Player GetPlayer(Guid id)
    {
        return _playersRepository.FindOne(id)!;
    }

    public void SavePlayer(Guid playerId, string name, Guid schoolId, Guid teamId)
    {
        var newPlayer = new Player(playerId, name, schoolId, teamId);
        
        _playerValidator.ValidatePlayer(newPlayer);
        
        _playersRepository.Save(newPlayer);
    }
}