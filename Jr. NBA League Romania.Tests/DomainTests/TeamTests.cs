using Jr._NBA_League_Romania.Domain;

namespace Jr._NBA_League_Romania.Tests.DomainTests;

public class TeamTests
{
    [Fact]
    public void Team_GetName_ReturnString()
    {
        //Arrange
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var id3 = Guid.NewGuid();

        const string name1 = "Team1";
        const string name2 = "Team2";
        const string name3 = "Team3";

        var team1 = new Team(id1, name1);
        var team2 = new Team(id2, name2);
        var team3 = new Team(id3, name3);

        //Act
        var expectedName1 = team1.Name;
        var expectedName2 = team2.Name;
        var expectedName3 = team3.Name;

        //Assert
        Assert.Equal(name1, expectedName1);
        Assert.Equal(name2, expectedName2);
        Assert.Equal(name3, expectedName3);
    }

    [Fact]
    public void Team_GetId_ReturnGuid()
    {
        //Arrange
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var id3 = Guid.NewGuid();
        
        const string name1 = "Team1";
        const string name2 = "Team2";
        const string name3 = "Team3";

        var team1 = new Team(id1, name1);
        var team2 = new Team(id2, name2);
        var team3 = new Team(id3, name3);
        
        //Act
        var expectedId1 = team1.Id;
        var expectedId2 = team2.Id;
        var expectedId3 = team3.Id;
        
        //Assert
        Assert.Equal(id1, expectedId1);
        Assert.Equal(id2, expectedId2);
        Assert.Equal(id3, expectedId3);
    }

    [Fact]
    public void Team_Equals_ReturnBoolean()
    {
        //Arrange
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();

        const string name1 = "Team1";
        const string name2 = "Team2";

        var team1 = new Team(id1, name1);
        var team2 = new Team(id2, name2);
        var team3 = new Team(id1, name1);

        //Act
        var actualResult1 = Equals(team1, team2);
        var actualResult2 = Equals(team1, team3);

        //Assert
        Assert.False(actualResult1);
        Assert.True(actualResult2);
    }
}