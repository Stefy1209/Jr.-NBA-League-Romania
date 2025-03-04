using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Utils;
using Jr._NBA_League_Romania.Validator;

namespace Jr._NBA_League_Romania.Service;

public class MainService
{
    private readonly TeamService _teamService = new();
    private readonly SchoolService _schoolService = new();
    private readonly PlayerService _playerService = new();
    private readonly GameService _gameService = new();
    private readonly ActivePlayerService _activePlayerService = new();
    
    private readonly MainValidator _mainValidator = new();
    
    private readonly Random _random = new();

    public void SaveTeam(string teamName, string schoolName)
    {
        var id = Guid.NewGuid();
        
        _teamService.SaveTeam(id, teamName);
        _schoolService.SaveSchool(id, schoolName);

        for (var i = 0; i < 15; i++)
        {
            var playerId = Guid.NewGuid();
            var fullName = NameGenerator.GenerateName();
            
            _playerService.SavePlayer(playerId, fullName, id, id);
        }
    }

    public void SaveGame(string team1, string team2, string dateTime)
    {
        _mainValidator.TeamNameExists(team1);
        _mainValidator.TeamNameExists(team2);

        var team1Id = _teamService.GetTeams()
            .First(team => team.Name == team1)
            .Id;

        var team2Id = _teamService.GetTeams()
            .First(team => team.Name == team2)
            .Id;
        
        var date = DateTime.ParseExact(dateTime, "dd-MM-yyyy HH:mm", System.Globalization.CultureInfo.InvariantCulture);
        
        var gameId = Guid.NewGuid();
        
        _gameService.SaveGame(gameId, team1Id, team2Id, date);

        var playersTeam1 = _playerService.GetPlayers()
            .Where(player => player.TeamId == team1Id)
            .ToArray();
        
        FischerYatesShuffle(playersTeam1);
        
        var playersTeam2 = _playerService.GetPlayers()
            .Where(player => player.TeamId == team2Id)
            .ToArray();
        
        FischerYatesShuffle(playersTeam2);

        for (var i = 0; i < 10; i++)
        {
            var activePlayerId = Guid.NewGuid();
            var playerId = playersTeam1[i].Id;
            var nrPointsScored = (byte)_random.Next(41);
            var activePlayerType = (ActivePlayerType)(i%2);
            
            _activePlayerService.SaveActivePlayer(activePlayerId, playerId, gameId, nrPointsScored, activePlayerType);
        }

        for (var i = 0; i < 10; i++)
        {
            var activePlayerId = Guid.NewGuid();
            var playerId = playersTeam2[i].Id;
            var nrPointsScored = (byte)_random.Next(41);
            var activePlayerType = (ActivePlayerType)(i%2);
            
            _activePlayerService.SaveActivePlayer(activePlayerId, playerId, gameId, nrPointsScored, activePlayerType);
        }
    }

    public IEnumerable<Player> GetAllPlayersByTeam(string teamName)
    {
        _mainValidator.TeamNameExists(teamName);
        
        var teamId = 
            from team in _teamService.GetTeams()
            where teamName == team.Name
            select team.Id;

        var players =
            from player in _playerService.GetPlayers()
            where teamId.First() == player.TeamId
            select player;
        
        return players;
    }

    public IEnumerable<Tuple<ActivePlayer, Player>> GetAllActivePlayersByTeamAndGame(string teamName, string team1Name, string team2Name)
    {
        _mainValidator.TeamNameExists(teamName);
        _mainValidator.TeamNameExists(team1Name);
        _mainValidator.TeamNameExists(team2Name);
        
        _mainValidator.GameExists(team1Name, team2Name);

        if (teamName != team1Name && teamName != team2Name)
            throw new ArgumentException("Team name does not correspond to the game");

        var team1Id = _teamService.GetTeams()
            .First(team => team.Name == team1Name)
            .Id;
        
        var team2Id = _teamService.GetTeams()
            .First(team => team.Name == team2Name)
            .Id;

        var teamId = team1Name == teamName ? team1Id : team2Id;

        var gameId = _gameService.GetGames()
            .First(game => game.IdTeam1 == team1Id && game.IdTeam2 == team2Id)
            .Id;

        var activePlayers = _activePlayerService.GetActivePlayers()
            .Where(activePlayer => gameId == activePlayer.GameId)
            .Select(activePlayer => new Tuple<ActivePlayer, Player>(activePlayer, _playerService.GetPlayer(activePlayer.PlayerId)))
            .Where(tuple => teamId == tuple.Item2.TeamId);

        return activePlayers;
    }

    public IEnumerable<Tuple<Game, Tuple<Team, Team>>> GetAllGamesBetweenDates(DateTime startDate, DateTime endDate)
    {
        var games = _gameService.GetGames()
            .Where(game => startDate <= game.DateTime && game.DateTime <= endDate)
            .Select(game => new Tuple<Game, Tuple<Team, Team>>(game, new Tuple<Team, Team>(_teamService.GetTeam(game.IdTeam1)!, _teamService.GetTeam(game.IdTeam2)!)));
        
        return games;
    }

    public Tuple<byte, byte> GetGameScore(string team1Name, string team2Name)
    {
        _mainValidator.TeamNameExists(team1Name);
        _mainValidator.TeamNameExists(team2Name);
        
        _mainValidator.GameExists(team1Name, team2Name);

        var team1Id = _teamService.GetTeams()
            .First(team => team1Name == team.Name)
            .Id;

        var team2Id = _teamService.GetTeams()
            .First(team => team2Name == team.Name)
            .Id;

        var gameId = _gameService.GetGames()
            .First(game => team1Id == game.IdTeam1 && team2Id == game.IdTeam2)
            .Id;

        var activePlayersGame = _activePlayerService.GetActivePlayers()
            .Where(activePlayer => gameId == activePlayer.GameId)
            .ToList();

        var activePlayersTeam1 = activePlayersGame
            .Where(activePlayer => _playerService.GetPlayer(activePlayer.PlayerId).TeamId == team1Id);
        
        var activePlayersTeam2 = activePlayersGame
            .Where(activePlayer => _playerService.GetPlayer(activePlayer.PlayerId).TeamId == team2Id);
        
        var scoreTeam1 = activePlayersTeam1.Aggregate<ActivePlayer, byte>(0, (current, activePlayer) => (byte)(current + activePlayer.NrPointsScored));
        var scoreTeam2 = activePlayersTeam2.Aggregate<ActivePlayer, byte>(0, (current, activePlayer) => (byte)(current + activePlayer.NrPointsScored));
        
        return new Tuple<byte, byte>(scoreTeam1, scoreTeam2);
    }

    private void FischerYatesShuffle(Array array)
    {
        var n = array.Length;

        while (n > 1)
        {
            n--;
            var k = _random.Next(n + 1);
            var value = array.GetValue(k);
            array.SetValue(array.GetValue(n), k);
            array.SetValue(value, n);
        }
    }
}