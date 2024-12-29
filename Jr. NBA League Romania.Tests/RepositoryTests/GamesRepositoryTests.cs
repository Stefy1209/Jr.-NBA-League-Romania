using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;
using Npgsql;

namespace Jr._NBA_League_Romania.Tests.RepositoryTests;

public class GamesRepositoryTests
{
    //Arrange
    private readonly GamesRepository _gamesRepository = new();
    
    private static readonly Guid Game1Id = Guid.NewGuid();
    private static readonly Guid Game2Id = Guid.NewGuid();
    private static readonly Guid Game3Id = Guid.NewGuid();
    
    private static readonly Guid Team1Id = Guid.NewGuid();
    private static readonly Guid Team2Id = Guid.NewGuid();
    private static readonly Guid Team3Id = Guid.NewGuid();
    
    private static readonly DateTime DateTime1 = DateTime.Now;
    private static readonly DateTime DateTime2 = DateTime.MinValue;
    private static readonly DateTime DateTime3 = DateTime.MaxValue;

    private readonly Game _game1 = new(Game1Id, Team1Id, Team2Id, DateTime1);
    private readonly Game _game2 = new(Game2Id, Team2Id, Team3Id, DateTime2);
    private readonly Game _game3 = new(Game3Id, Team3Id, Team1Id, DateTime3);
    
    private readonly TeamsRepository _teamsRepository = new();
    
    private const string Team1Name = "Team 1";
    private const string Team2Name = "Team 2";
    private const string Team3Name = "Team 3";

    private readonly Team _team1 = new(Team1Id, Team1Name);
    private readonly Team _team2 = new(Team2Id, Team2Name);
    private readonly Team _team3 = new(Team3Id, Team3Name);

    [Fact]
    public void Repo_Save_ReturnGame()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        //Act
        var actualResult1 = _gamesRepository.Save(_game1);
        var actualResult2 = _gamesRepository.Save(_game2);
        var actualResult3 = _gamesRepository.Save(_game3);
        
        //Assert
        Assert.Null(actualResult1);
        Assert.Null(actualResult2);
        Assert.Null(actualResult3);
        Assert.Throws<PostgresException>(() => _gamesRepository.Save(_game1));
        
        //*Clean
        _gamesRepository.Delete(_game1.Id);
        _gamesRepository.Delete(_game2.Id);
        _gamesRepository.Delete(_game3.Id);

        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }

    [Fact]
    public void Repo_Delete_ReturnGame()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);

        _gamesRepository.Save(_game1);
        _gamesRepository.Save(_game2);
        _gamesRepository.Save(_game3);
        
        //Act
        var actualResult1 = _gamesRepository.Delete(_game1.Id);
        var actualResult2 = _gamesRepository.Delete(_game2.Id);
        var actualResult3 = _gamesRepository.Delete(_game3.Id);
        var actualResult4 = _gamesRepository.Delete(_game1.Id);
        
        //Assert
        Assert.Equal(_game1, actualResult1);
        Assert.Equal(_game2, actualResult2);
        Assert.Equal(_game3, actualResult3);
        Assert.Null(actualResult4);
        
        //*Clean
        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }

    [Fact]
    public void Repo_FindOne_ReturnGame()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        _gamesRepository.Save(_game1);
        _gamesRepository.Save(_game2);
        _gamesRepository.Save(_game3);
        
        //Act
        var actualResult1 = _gamesRepository.FindOne(_game1.Id);
        var actualResult2 = _gamesRepository.FindOne(_game2.Id);
        var actualResult3 = _gamesRepository.FindOne(_game3.Id);
        var actualResult4 = _gamesRepository.FindOne(Guid.NewGuid());
        
        //Assert
        Assert.Equal(_game1, actualResult1);
        Assert.Equal(_game2, actualResult2);
        Assert.Equal(_game3, actualResult3);
        Assert.Null(actualResult4);
        
        //*Clean
        _gamesRepository.Delete(_game1.Id);
        _gamesRepository.Delete(_game2.Id);
        _gamesRepository.Delete(_game3.Id);
        
        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }

    [Fact]
    public void Repo_FindAll_ReturnGame()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        _gamesRepository.Save(_game1);
        _gamesRepository.Save(_game2);
        _gamesRepository.Save(_game3);
        
        //Act
        var list = _gamesRepository.FindAll().ToList();
        
        //Assert
        Assert.Collection(list, 
            game => Assert.Equal(_game1, game),
            game => Assert.Equal(_game2, game),
            game => Assert.Equal(_game3, game));
        
        //*Clean
        _gamesRepository.Delete(_game1.Id);
        _gamesRepository.Delete(_game2.Id);
        _gamesRepository.Delete(_game3.Id);
        
        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }
}