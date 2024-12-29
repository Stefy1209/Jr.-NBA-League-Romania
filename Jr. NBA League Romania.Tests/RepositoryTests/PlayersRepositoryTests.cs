using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;

namespace Jr._NBA_League_Romania.Tests.RepositoryTests;

public class PlayersRepositoryTests
{
    //Arrange
    private readonly PlayersRepository _playersRepository = new();
    
    private static readonly Guid Player1Id = Guid.NewGuid();
    private static readonly Guid Player2Id = Guid.NewGuid();
    private static readonly Guid Player3Id = Guid.NewGuid();
    
    private const string Player1Name = "John Doe";
    private const string Player2Name = "John Smith";
    private const string Player3Name = "John Jones";
    
    private static readonly Guid Team1Id = Guid.NewGuid();
    private static readonly Guid Team2Id = Guid.NewGuid();
    private static readonly Guid Team3Id = Guid.NewGuid();
    
    private readonly Player _player1 = new(Player1Id, Player1Name, Team1Id, Team1Id);
    private readonly Player _player2 = new(Player2Id, Player2Name, Team2Id, Team2Id);
    private readonly Player _player3 = new(Player3Id, Player3Name, Team3Id, Team3Id);
    
    private const string Team1Name = "Red Team";
    private const string Team2Name = "Blue Team";
    private const string Team3Name = "Green Team";

    private readonly TeamsRepository _teamsRepository = new();
    
    private readonly Team _team1 = new(Team1Id, Team1Name);
    private readonly Team _team2 = new(Team2Id, Team2Name);
    private readonly Team _team3 = new(Team3Id, Team3Name);

    [Fact]
    public void Repo_Save_ReturnPlayer()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        //Act
        var actualResult1 = _playersRepository.Save(_player1);
        var actualResult2 = _playersRepository.Save(_player2);
        var actualResult3 = _playersRepository.Save(_player3);
        
        try
        {
            var actualResult4 = _playersRepository.Save(_player1);
            
            Assert.NotNull(actualResult4);
        }
        catch (Exception)
        {
            //ignored
        }
        
        //Assert
        Assert.Null(actualResult1);
        Assert.Null(actualResult2);
        Assert.Null(actualResult3);
        
        //*Clean
        _playersRepository.Delete(_player1.Id);
        _playersRepository.Delete(_player2.Id);
        _playersRepository.Delete(_player3.Id);
        
        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }

    [Fact]
    public void Repo_Delete_ReturnPlayer()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);

        _playersRepository.Save(_player1);
        _playersRepository.Save(_player2);
        _playersRepository.Save(_player3);
        
        //Act
        var actualResult1 = _playersRepository.Delete(_player1.Id);
        var actualResult2 = _playersRepository.Delete(_player2.Id);
        var actualResult3 = _playersRepository.Delete(_player3.Id);
        var actualResult4 = _playersRepository.Delete(_player1.Id);
        
        //Assert
        Assert.Equal(_player1, actualResult1);
        Assert.Equal(_player2, actualResult2);
        Assert.Equal(_player3, actualResult3);
        Assert.Null(actualResult4);
        
        //*Clean
        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }

    [Fact]
    public void Repo_FindOne_ReturnPlayer()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        _playersRepository.Save(_player1);
        _playersRepository.Save(_player2);
        _playersRepository.Save(_player3);
        
        //Act
        var actualResult1 = _playersRepository.FindOne(_player1.Id);
        var actualResult2 = _playersRepository.FindOne(_player2.Id);
        var actualResult3 = _playersRepository.FindOne(_player3.Id);
        var actualResult4 = _playersRepository.FindOne(Guid.NewGuid());
        
        //Assert
        Assert.Equal(_player1, actualResult1);
        Assert.Equal(_player2, actualResult2);
        Assert.Equal(_player3, actualResult3);
        Assert.Null(actualResult4);
        
        //*Clean
        _playersRepository.Delete(_player1.Id);
        _playersRepository.Delete(_player2.Id);
        _playersRepository.Delete(_player3.Id);
        
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
        
        _playersRepository.Save(_player1);
        _playersRepository.Save(_player2);
        _playersRepository.Save(_player3);
        
        //Act
        var list = _playersRepository.FindAll().ToList();
        
        //Assert
        Assert.Collection(list,
            player => Assert.Equal(_player1, player),
            player => Assert.Equal(_player2, player),
            player => Assert.Equal(_player3, player));
        
        //*Clean
        _playersRepository.Delete(_player1.Id);
        _playersRepository.Delete(_player2.Id);
        _playersRepository.Delete(_player3.Id);
        
        _teamsRepository.Delete(_team1.Id);
        _teamsRepository.Delete(_team2.Id);
        _teamsRepository.Delete(_team3.Id);
    }
}