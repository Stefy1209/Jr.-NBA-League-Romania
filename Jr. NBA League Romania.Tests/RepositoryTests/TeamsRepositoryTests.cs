using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;

namespace Jr._NBA_League_Romania.Tests.RepositoryTests;

public class TeamsRepositoryTests
{
    //Arrange
    private readonly TeamsRepository _teamsRepository = new();

    private static readonly Guid Team1Id = Guid.NewGuid();
    private static readonly Guid Team2Id = Guid.NewGuid();
    private static readonly Guid Team3Id = Guid.NewGuid();
    
    private const string Team1Name = "Team 1";
    private const string Team2Name = "Team 2";
    private const string Team3Name = "Team 3";
    
    private readonly Team _team1 = new(Team1Id, Team1Name);
    private readonly Team _team2 = new(Team2Id, Team2Name);
    private readonly Team _team3 = new(Team3Id, Team3Name);

    [Fact]
    public void Repo_Save_ReturnTeam()
    {
        //Act
        var actualResult1 = _teamsRepository.Save(_team1);
        var actualResult2 = _teamsRepository.Save(_team2);
        var actualResult3 = _teamsRepository.Save(_team3);
        
        try
        {
            var actualResult4 = _teamsRepository.Save(_team1); //if entity with given id already exists
            
            Assert.Equal(_team1, actualResult4);
        }
        catch (Exception)
        {
            // ignored
        }

        //Assert
        Assert.Null(actualResult1);
        Assert.Null(actualResult2);
        Assert.Null(actualResult3);

        //*Clean
        _teamsRepository.Delete(Team1Id);
        _teamsRepository.Delete(Team2Id);
        _teamsRepository.Delete(Team3Id);
    }
    
    [Fact]
    public void Repo_FindOne_ReturnTeam()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        //Act
        var actualResult1 = _teamsRepository.FindOne(Team1Id);
        var actualResult2 = _teamsRepository.FindOne(Team2Id);
        var actualResult3 = _teamsRepository.FindOne(Team3Id);
        var actualResult4 = _teamsRepository.FindOne(Guid.NewGuid());
        
        //Assert
        Assert.Equal(_team1, actualResult1);
        Assert.Equal(_team2, actualResult2);
        Assert.Equal(_team3, actualResult3);
        Assert.Null(actualResult4);
        
        //*Clean
        _teamsRepository.Delete(Team1Id);
        _teamsRepository.Delete(Team2Id);
        _teamsRepository.Delete(Team3Id);
    }
    
    [Fact]
    public void Repo_FindAll_ReturnTeams()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        //Act 
        var list = _teamsRepository.FindAll().ToList();
        
        //Assert
        Assert.Equal(3, list.Count);
        Assert.Collection(list,
            team => Assert.Equal(Team1Id, team.Id),
            team => Assert.Equal(Team2Id, team.Id),
            team => Assert.Equal(Team3Id, team.Id)
            );
        
        //*Clean
        _teamsRepository.Delete(Team1Id);
        _teamsRepository.Delete(Team2Id);
        _teamsRepository.Delete(Team3Id);
    }
    
    [Fact]
    public void Repo_Delete_ReturnTeam()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        //Act
        var actualResult1 = _teamsRepository.Delete(Team1Id);
        var actualResult2 = _teamsRepository.Delete(Team2Id);
        var actualResult3 = _teamsRepository.Delete(Team3Id);
        var actualResult4 = _teamsRepository.Delete(Team1Id);
        
        //Assert
        Assert.Equal(_team1, actualResult1);
        Assert.Equal(_team2, actualResult2);
        Assert.Equal(_team3, actualResult3);
        Assert.Null(actualResult4);
    }
}