using System.ComponentModel.DataAnnotations;
using Jr._NBA_League_Romania.Repository;

namespace Jr._NBA_League_Romania.Validator;

public class MainValidator
{
    private readonly TeamsRepository _teamsRepository = new();
    private readonly GamesRepository _gamesRepository = new();

    public void TeamNameExists(string teamName)
    {
        var teams =
            from team in _teamsRepository.FindAll()
            where teamName == team.Name
            select team;

        if (!teams.Any()) throw new ValidationException($"There is no team with name {teamName}");
    }

    public void GameExists(string teamName1, string teamName2)
    {
        var team1Ids =
            from team in _teamsRepository.FindAll()
            where teamName1 == team.Name
            select team.Id;
        
        var team2Ids =
            from team in _teamsRepository.FindAll()
            where teamName2 == team.Name
            select team.Id;

        var team1Id = team1Ids.First();
        var team2Id = team2Ids.First();
        
        var games =
            from game in _gamesRepository.FindAll()
            where team1Id == game.IdTeam1 && team2Id == game.IdTeam2
            select game;
        
        if(!games.Any()) throw new ValidationException($"There is no game between {teamName1} and {teamName2}");
    }
}