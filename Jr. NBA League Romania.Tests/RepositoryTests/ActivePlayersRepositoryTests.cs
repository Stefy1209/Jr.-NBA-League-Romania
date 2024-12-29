using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;
using Npgsql;

namespace Jr._NBA_League_Romania.Tests.RepositoryTests;

public class ActivePlayersRepositoryTests
{
    //Arrange
    private readonly ActivePlayersRepository _activePlayersRepository = new();
    
    private static readonly Guid ActivePlayer1Id = Guid.NewGuid();
    private static readonly Guid ActivePlayer2Id = Guid.NewGuid();
    private static readonly Guid ActivePlayer3Id = Guid.NewGuid();
    
    private static readonly Guid Game1Id = Guid.NewGuid();
    private static readonly Guid Game2Id = Guid.NewGuid();
    private static readonly Guid Game3Id = Guid.NewGuid();
    
    private static readonly Guid Player1Id = Guid.NewGuid();
    private static readonly Guid Player2Id = Guid.NewGuid();
    private static readonly Guid Player3Id = Guid.NewGuid();
    
    private const byte NrPointsScored1 = 1;
    private const byte NrPointsScored2 = 2;
    private const byte NrPointsScored3 = 3;

    private const ActivePlayerType ActivePlayerType1 = ActivePlayerType.Active;
    private const ActivePlayerType ActivePlayerType2 = ActivePlayerType.Substitute;
    private const ActivePlayerType ActivePlayerType3 = ActivePlayerType.Active;

    private readonly ActivePlayer _activePlayer1 = new(ActivePlayer1Id, Player1Id, Game1Id, NrPointsScored1, ActivePlayerType1);
    private readonly ActivePlayer _activePlayer2 = new(ActivePlayer2Id, Player2Id, Game2Id, NrPointsScored2, ActivePlayerType2);
    private readonly ActivePlayer _activePlayer3 = new(ActivePlayer3Id, Player3Id, Game3Id, NrPointsScored3, ActivePlayerType3);
    
    private static readonly Guid Team1Id = Guid.NewGuid();
    private static readonly Guid Team2Id = Guid.NewGuid();
    private static readonly Guid Team3Id = Guid.NewGuid();
    
    private static readonly DateTime DateTime1 = DateTime.Now;
    private static readonly DateTime DateTime2 = DateTime.MinValue;
    private static readonly DateTime DateTime3 = DateTime.MaxValue;

    private readonly Game _game1 = new(Game1Id, Team1Id, Team2Id, DateTime1);
    private readonly Game _game2 = new(Game2Id, Team2Id, Team3Id, DateTime2);
    private readonly Game _game3 = new(Game3Id, Team1Id, Team3Id, DateTime3);
    
    private readonly GamesRepository _gamesRepository = new();
    
    private const string Player1Name = "Player 1";
    private const string Player2Name = "Player 2";
    private const string Player3Name = "Player 3";

    private readonly Player _player1 = new(Player1Id, Player1Name, Team1Id, Team1Id);
    private readonly Player _player2 = new(Player2Id, Player2Name, Team2Id, Team2Id);
    private readonly Player _player3 = new(Player3Id, Player3Name, Team3Id, Team3Id);
    
    private readonly PlayersRepository _playersRepository = new();
    
    private const string Team1Name = "Team 1";
    private const string Team2Name = "Team 2";
    private const string Team3Name = "Team 3";

    private readonly Team _team1 = new(Team1Id, Team1Name);
    private readonly Team _team2 = new(Team2Id, Team2Name);
    private readonly Team _team3 = new(Team3Id, Team3Name);
    
    private readonly TeamsRepository _teamsRepository = new();

    [Fact]
    public void Repo_Save_ReturnActivePlayer()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        _gamesRepository.Save(_game1);
        _gamesRepository.Save(_game2);
        _gamesRepository.Save(_game3);
        
        _playersRepository.Save(_player1);
        _playersRepository.Save(_player2);
        _playersRepository.Save(_player3);
        
        //Act
        var actualResult1 = _activePlayersRepository.Save(_activePlayer1);
        var actualResult2 = _activePlayersRepository.Save(_activePlayer2);
        var actualResult3 = _activePlayersRepository.Save(_activePlayer3);
        
        //Assert
        Assert.Null(actualResult1);
        Assert.Null(actualResult2);
        Assert.Null(actualResult3);
        Assert.Throws<PostgresException>(() => _activePlayersRepository.Save(_activePlayer1));
        
        //*Clean
        _activePlayersRepository.Delete(_activePlayer1.Id);
        _activePlayersRepository.Delete(_activePlayer2.Id);
        _activePlayersRepository.Delete(_activePlayer3.Id);
        
        _playersRepository.Delete(_player1.Id);
        _playersRepository.Delete(_player2.Id);
        _playersRepository.Delete(_player3.Id);
        
        _gamesRepository.Delete(_game1.Id);
        _gamesRepository.Delete(_game2.Id);
        _gamesRepository.Delete(_game3.Id);
        
        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }

    [Fact]
    public void Repo_Delete_ReturnActivePlayer()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        _gamesRepository.Save(_game1);
        _gamesRepository.Save(_game2);
        _gamesRepository.Save(_game3);
        
        _playersRepository.Save(_player1);
        _playersRepository.Save(_player2);
        _playersRepository.Save(_player3);

        _activePlayersRepository.Save(_activePlayer1);
        _activePlayersRepository.Save(_activePlayer2);
        _activePlayersRepository.Save(_activePlayer3);
        
        //Act
        var actualResult1 = _activePlayersRepository.Delete(_activePlayer1.Id);
        var actualResult2 = _activePlayersRepository.Delete(_activePlayer2.Id);
        var actualResult3 = _activePlayersRepository.Delete(_activePlayer3.Id);
        var actualResult4 = _activePlayersRepository.Delete(_player1.Id);
        
        //Assert
        Assert.Equal(_activePlayer1, actualResult1);
        Assert.Equal(_activePlayer2, actualResult2);
        Assert.Equal(_activePlayer3, actualResult3);
        Assert.Null(actualResult4);
        
        //*Clean
        _playersRepository.Delete(_player1.Id);
        _playersRepository.Delete(_player2.Id);
        _playersRepository.Delete(_player3.Id);
        
        _gamesRepository.Delete(_game1.Id);
        _gamesRepository.Delete(_game2.Id);
        _gamesRepository.Delete(_game3.Id);
        
        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }

    [Fact]
    public void Repo_FindOne_ReturnActivePlayer()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        _gamesRepository.Save(_game1);
        _gamesRepository.Save(_game2);
        _gamesRepository.Save(_game3);
        
        _playersRepository.Save(_player1);
        _playersRepository.Save(_player2);
        _playersRepository.Save(_player3);

        _activePlayersRepository.Save(_activePlayer1);
        _activePlayersRepository.Save(_activePlayer2);
        _activePlayersRepository.Save(_activePlayer3);
        
        //Act
        var actualResult1 = _activePlayersRepository.FindOne(_activePlayer1.Id);
        var actualResult2 = _activePlayersRepository.FindOne(_activePlayer2.Id);
        var actualResult3 = _activePlayersRepository.FindOne(_activePlayer3.Id);
        var actualResult4 = _activePlayersRepository.FindOne(Guid.NewGuid());
        
        //Assert
        Assert.Equal(_activePlayer1, actualResult1);
        Assert.Equal(_activePlayer2, actualResult2);
        Assert.Equal(_activePlayer3, actualResult3);
        Assert.Null(actualResult4);
        
        //*Clean
        _activePlayersRepository.Delete(_activePlayer1.Id);
        _activePlayersRepository.Delete(_activePlayer2.Id);
        _activePlayersRepository.Delete(_activePlayer3.Id);
        
        _playersRepository.Delete(_player1.Id);
        _playersRepository.Delete(_player2.Id);
        _playersRepository.Delete(_player3.Id);
        
        _gamesRepository.Delete(_game1.Id);
        _gamesRepository.Delete(_game2.Id);
        _gamesRepository.Delete(_game3.Id);
        
        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }

    [Fact]
    public void Repo_FindAll_ReturnEnumerable()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        _gamesRepository.Save(_game1);
        _gamesRepository.Save(_game2);
        _gamesRepository.Save(_game3);
        
        _playersRepository.Save(_player1);
        _playersRepository.Save(_player2);
        _playersRepository.Save(_player3);

        _activePlayersRepository.Save(_activePlayer1);
        _activePlayersRepository.Save(_activePlayer2);
        _activePlayersRepository.Save(_activePlayer3);
        
        //Act
        var list = _activePlayersRepository.FindAll().ToList();
        
        //Assert
        Assert.Collection(list,
            activePlayer => Assert.Equal(_activePlayer1, activePlayer),
            activePlayer => Assert.Equal(_activePlayer2, activePlayer),
            activePlayer => Assert.Equal(_activePlayer3, activePlayer));
        
        //*Clean
        _activePlayersRepository.Delete(_activePlayer1.Id);
        _activePlayersRepository.Delete(_activePlayer2.Id);
        _activePlayersRepository.Delete(_activePlayer3.Id);
        
        _playersRepository.Delete(_player1.Id);
        _playersRepository.Delete(_player2.Id);
        _playersRepository.Delete(_player3.Id);
        
        _gamesRepository.Delete(_game1.Id);
        _gamesRepository.Delete(_game2.Id);
        _gamesRepository.Delete(_game3.Id);
        
        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }
}