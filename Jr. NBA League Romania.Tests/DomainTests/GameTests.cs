using Jr._NBA_League_Romania.Domain;

namespace Jr._NBA_League_Romania.Tests.DomainTests;

public class GameTests
{
    //Arrange
    private static readonly Guid Id1 = Guid.NewGuid();
    private static readonly Guid Id2 = Guid.NewGuid();
    private static readonly Guid Id3 = Guid.NewGuid();
    
    private static readonly Guid IdTeam11 = Guid.NewGuid();
    private static readonly Guid IdTeam12 = Guid.NewGuid();
    private static readonly Guid IdTeam13 = Guid.NewGuid();
    
    private static readonly Guid IdTeam21 = Guid.NewGuid();
    private static readonly Guid IdTeam22 = Guid.NewGuid();
    private static readonly Guid IdTeam23 = Guid.NewGuid();
    
    private static readonly DateTime DateTime1 = DateTime.Now;
    private static readonly DateTime DateTime2 = DateTime.MinValue;
    private static readonly DateTime DateTime3 = DateTime.MaxValue;
    
    private readonly Game _game1 = new(Id1, IdTeam11, IdTeam21, DateTime1);
    private readonly Game _game2 = new(Id2, IdTeam12, IdTeam22, DateTime2);
    private readonly Game _game3 = new(Id3, IdTeam13, IdTeam23, DateTime3);

    [Fact]
    public void Game_GetId_ReturnGuid()
    {
        //Act
        var actualId1 = _game1.Id;
        var actualId2 = _game2.Id;
        var actualId3 = _game3.Id;

        //Assert
        Assert.Equal(Id1, actualId1);
        Assert.Equal(Id2, actualId2);
        Assert.Equal(Id3, actualId3);
    }

    [Fact]
    public void Game_GetIdTeam1_ReturnGuid()
    {
        //Act
        var actualIdTeam11 = _game1.IdTeam1;
        var actualIdTeam12 = _game2.IdTeam1;
        var actualIdTeam13 = _game3.IdTeam1;
        
        //Assert
        Assert.Equal(IdTeam11, actualIdTeam11);
        Assert.Equal(IdTeam12, actualIdTeam12);
        Assert.Equal(IdTeam13, actualIdTeam13);
    }

    [Fact]
    public void Game_GetIdTeam2_ReturnGuid()
    {
        //Act
        var actualIdTeam21 = _game1.IdTeam2;
        var actualIdTeam22 = _game2.IdTeam2;
        var actualIdTeam23 = _game3.IdTeam2;
        
        //Assert
        Assert.Equal(IdTeam21, actualIdTeam21);
        Assert.Equal(IdTeam22, actualIdTeam22);
        Assert.Equal(IdTeam23, actualIdTeam23);
    }

    [Fact]
    public void Game_GetDateTime_ReturnDateTime()
    {
        //Act
        var actualDateTime1 = _game1.DateTime;
        var actualDateTime2 = _game2.DateTime;
        var actualDateTime3 = _game3.DateTime;
        
        //Assert
        Assert.Equal(DateTime1, actualDateTime1);
        Assert.Equal(DateTime2, actualDateTime2);
        Assert.Equal(DateTime3, actualDateTime3);
    }
}