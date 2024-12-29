using Jr._NBA_League_Romania.Domain;
using Jr._NBA_League_Romania.Repository;

namespace Jr._NBA_League_Romania.Tests.RepositoryTests;

public class SchoolsRepositoryTests
{
    //Arrange
    private readonly SchoolsRepository _schoolsRepository = new();

    private static readonly Guid Id1 = Guid.NewGuid();
    private static readonly Guid Id2 = Guid.NewGuid();
    private static readonly Guid Id3 = Guid.NewGuid();
    
    private const string School1Name = "School 1";
    private const string School2Name = "School 2";
    private const string School3Name = "School 3";
    
    private readonly School _school1 = new(Id1, School1Name);
    private readonly School _school2 = new(Id2, School2Name);
    private readonly School _school3 = new(Id3, School3Name);
    
    
    private readonly TeamsRepository _teamsRepository = new();
    
    private const string Team1Name = "Team 1";
    private const string Team2Name = "Team 2";
    private const string Team3Name = "Team 3";
    
    private readonly Team _team1 = new(Id1, Team1Name);
    private readonly Team _team2 = new(Id2, Team2Name);
    private readonly Team _team3 = new(Id3, Team3Name);

    [Fact]
    public void Repo_Save_ReturnSchool()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        //Act
        var actualResult1 = _schoolsRepository.Save(_school1);
        var actualResult2 = _schoolsRepository.Save(_school2);
        var actualResult3 = _schoolsRepository.Save(_school3);
        
        try
        {
            var actualResult4 = _schoolsRepository.Save(_school1); //if entity with given id already exists
            
            Assert.Equal(_school1, actualResult4);
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
        _schoolsRepository.Delete(Id1);
        _schoolsRepository.Delete(Id2);
        _schoolsRepository.Delete(Id3);

        _teamsRepository.Delete(Id1);
        _teamsRepository.Delete(Id2);
        _teamsRepository.Delete(Id3);
    }
    
    [Fact]
    public void Repo_FindOne_ReturnSchool()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        _schoolsRepository.Save(_school1);
        _schoolsRepository.Save(_school2);
        _schoolsRepository.Save(_school3);
        
        //Act
        var actualResult1 = _schoolsRepository.FindOne(Id1);
        var actualResult2 = _schoolsRepository.FindOne(Id2);
        var actualResult3 = _schoolsRepository.FindOne(Id3);
        var actualResult4 = _schoolsRepository.FindOne(Guid.NewGuid());
        
        //Assert
        Assert.Equal(_school1, actualResult1);
        Assert.Equal(_school2, actualResult2);
        Assert.Equal(_school3, actualResult3);
        Assert.Null(actualResult4);
        
        //*Clean
        _schoolsRepository.Delete(Id1);
        _schoolsRepository.Delete(Id2);
        _schoolsRepository.Delete(Id3);
        
        _teamsRepository.Delete(Id1);
        _teamsRepository.Delete(Id2);
        _teamsRepository.Delete(Id3);
    }
    
    [Fact]
    public void Repo_FindAll_ReturnTeams()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        _schoolsRepository.Save(_school1);
        _schoolsRepository.Save(_school2);
        _schoolsRepository.Save(_school3);
        
        //Act 
        var list = _schoolsRepository.FindAll().ToList();
        
        //Assert
        Assert.Equal(3, list.Count);
        Assert.Collection(list,
            school => Assert.Equal(Id1, school.Id),
            school => Assert.Equal(Id2, school.Id),
            school => Assert.Equal(Id3, school.Id)
            );
        
        //*Clean
        _schoolsRepository.Delete(Id1);
        _schoolsRepository.Delete(Id2);
        _schoolsRepository.Delete(Id3);
        
        _teamsRepository.Delete(Id1);
        _teamsRepository.Delete(Id2);
        _teamsRepository.Delete(Id3);
    }
    
    [Fact]
    public void Repo_Delete_ReturnTeam()
    {
        //Arrange
        _teamsRepository.Save(_team1);
        _teamsRepository.Save(_team2);
        _teamsRepository.Save(_team3);
        
        _schoolsRepository.Save(_school1);
        _schoolsRepository.Save(_school2);
        _schoolsRepository.Save(_school3);
        
        //Act
        var actualResult1 = _schoolsRepository.Delete(Id1);
        var actualResult2 = _schoolsRepository.Delete(Id2);
        var actualResult3 = _schoolsRepository.Delete(Id3);
        var actualResult4 = _schoolsRepository.Delete(Id1);
        
        //Assert
        Assert.Equal(_school1, actualResult1);
        Assert.Equal(_school2, actualResult2);
        Assert.Equal(_school3, actualResult3);
        Assert.Null(actualResult4);
        
        //*Clean
        _teamsRepository.Delete(Id1);
        _teamsRepository.Delete(Id2);
        _teamsRepository.Delete(Id3);
    }
}