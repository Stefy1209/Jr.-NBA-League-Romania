using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;
using Jr._NBA_League_Romania.Validator;

namespace Jr._NBA_League_Romania.Service;

public class TeamService
{
    private readonly TeamsRepository _teamsRepository = new();
    private readonly TeamValidator _teamValidator = new();

    public IEnumerable<Team> GetTeams()
    {
        return _teamsRepository.FindAll();
    }

    public Team? GetTeam(Guid id)
    {
        return _teamsRepository.FindOne(id);
    }
    
    public void SaveTeam(Guid id, string name)
    {
        var team = new Team(id, name);
        
        _teamValidator.ValidateTeam(team);
        
        _teamsRepository.Save(team);
    }
}