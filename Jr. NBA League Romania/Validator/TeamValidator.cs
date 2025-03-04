using System.ComponentModel.DataAnnotations;
using System.Text;
using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;

namespace Jr._NBA_League_Romania.Validator;

public class TeamValidator
{
    private readonly TeamsRepository _teamsRepository = new();

    public void ValidateTeam(Team team)
    {
        var sb = new StringBuilder();
        var notValid = IdAlreadyExists(sb, team);
        
        if(notValid) throw new ValidationException(sb.ToString());
    }

    private bool IdAlreadyExists(StringBuilder sb, Team team)
    {
        if(_teamsRepository.FindOne(team.Id) == null) return false;
        
        sb.AppendLine($"Team with id {team.Id} already exists.");
        return true;
    }
}