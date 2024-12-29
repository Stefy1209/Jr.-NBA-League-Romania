using Jr._NBA_League_Romania.Domain;

namespace Jr._NBA_League_Romania.Tests.DomainTests;

public class PlayerTests
{
    //Arrange
    private static readonly Guid Id1 = Guid.NewGuid();
    private static readonly Guid Id2 = Guid.NewGuid();
    private static readonly Guid Id3 = Guid.NewGuid();
    
    private const string Name1 = "Name1";
    private const string Name2 = "Name2";
    private const string Name3 = "Name3";
    
    private static readonly Guid School1 = Guid.NewGuid();
    private static readonly Guid School2 = Guid.NewGuid();
    private static readonly Guid School3 = Guid.NewGuid();
    
    private static readonly Guid Team1Id = Guid.NewGuid();
    private static readonly Guid Team2Id = Guid.NewGuid();
    private static readonly Guid Team3Id = Guid.NewGuid();
    
    private readonly Player _player1 = new(Id1, Name1, School1, Team1Id);
    private readonly Player _player2 = new(Id2, Name2, School2, Team2Id);
    private readonly Player _player3 = new(Id3, Name3, School3, Team3Id);

    [Fact]
    public void Player_GetId_ReturnGuid()
    {
        //Act
        var expectedId1 = _player1.Id;
        var expectedId2 = _player2.Id;
        var expectedId3 = _player3.Id;
        
        //Assert
        Assert.Equal(Id1, expectedId1);
        Assert.Equal(Id2, expectedId2);
        Assert.Equal(Id3, expectedId3);
    }

    [Fact]
    public void Player_GetName_ReturnString()
    {
        //Act
        var expectedName1 = _player1.Name;
        var expectedName2 = _player2.Name;
        var expectedName3 = _player3.Name;
        
        //Assert
        Assert.Equal(Name1, expectedName1);
        Assert.Equal(Name2, expectedName2);
        Assert.Equal(Name3, expectedName3);
    }

    [Fact]
    public void Player_GetSchool_ReturnString()
    {
        //Act
        var expectedSchool1 = _player1.SchoolId;
        var expectedSchool2 = _player2.SchoolId;
        var expectedSchool3 = _player3.SchoolId;
        
        //Assert
        Assert.Equal(School1, expectedSchool1);
        Assert.Equal(School2, expectedSchool2);
        Assert.Equal(School3, expectedSchool3);
    }

    [Fact]
    public void Player_GetTeam_ReturnGuid()
    {
        //Act
        var expectedTeam1Id = _player1.TeamId;
        var expectedTeam2Id = _player2.TeamId;
        var expectedTeam3Id = _player3.TeamId;
        
        //Assert
        Assert.Equal(Team1Id, expectedTeam1Id);
        Assert.Equal(Team2Id, expectedTeam2Id);
        Assert.Equal(Team3Id, expectedTeam3Id);
    }
}