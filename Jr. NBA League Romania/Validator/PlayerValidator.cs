using System.ComponentModel.DataAnnotations;
using System.Text;
using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;

namespace Jr._NBA_League_Romania.Validator;

public class PlayerValidator
{
    private readonly TeamsRepository _teamsRepository = new();
    private readonly PlayersRepository _playersRepository = new();

    public void ValidatePlayer(Player player)
    {
        var sb = new StringBuilder();
        var notValid = PlayerIdExists(sb, player) || SchoolIdDoesntExists(sb, player);

        if (notValid) throw new ValidationException(sb.ToString());
    }

    private bool PlayerIdExists(StringBuilder sb, Player player)
    {
        if (_playersRepository.FindOne(player.Id) == null) return false;
        
        sb.AppendLine($"Player {player.Id} already exists.");
        return true;
    }

    private bool SchoolIdDoesntExists(StringBuilder sb, Player player)
    {
        if (_teamsRepository.FindOne(player.TeamId) != null) return false;
        
        sb.AppendLine($"Team {player.TeamId} does not exist.");
        return true;
    }
}