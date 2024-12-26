using Jr._NBA_League_Romania.Domain;

namespace Jr._NBA_League_Romania.Tests.DomainTests;

public class ActivePlayerTests
{
    //Arrange
    private static readonly Guid Id1 = Guid.NewGuid();
    private static readonly Guid Id2 = Guid.NewGuid();
    
    private static readonly Guid PlayerId1 = Guid.NewGuid();
    private static readonly Guid PlayerId2 = Guid.NewGuid();
    
    private static readonly Guid GameId1 = Guid.NewGuid();
    private static readonly Guid GameId2 = Guid.NewGuid();
    
    private const byte NrPointsScored1 = 0;
    private const byte NrPointsScored2 = 255;
    
    private const ActivePlayerType ActivePlayerType1 = ActivePlayerType.Active;
    private const ActivePlayerType ActivePlayerType2 = ActivePlayerType.Substitute;
    
    private readonly ActivePlayer _activePlayer1 = new(Id1, PlayerId1, GameId1, NrPointsScored1, ActivePlayerType1);
    private readonly ActivePlayer _activePlayer2 = new(Id2, PlayerId2, GameId2, NrPointsScored2, ActivePlayerType2);

    [Fact]
    public void ActivePlayer_GetId_ReturnGuid()
    {
        //Act
        var actualId1 = _activePlayer1.Id;
        var actualId2 = _activePlayer2.Id;

        //Assert
        Assert.Equal(Id1, actualId1);
        Assert.Equal(Id2, actualId2);
    }

    [Fact]
    public void ActivePlayer_GetPlayerId_ReturnGuid()
    {
        //Act
        var actualPlayerId1 = _activePlayer1.PlayerId;
        var actualPlayerId2 = _activePlayer2.PlayerId;
        
        //Assert
        Assert.Equal(PlayerId1, actualPlayerId1);
        Assert.Equal(PlayerId2, actualPlayerId2);
    }

    [Fact]
    public void ActivePlayer_GetGameId_ReturnGuid()
    {
        //Act
        var actualGameId1 = _activePlayer1.GameId;
        var actualGameId2 = _activePlayer2.GameId;
        
        //Assert
        Assert.Equal(GameId1, actualGameId1);
        Assert.Equal(GameId2, actualGameId2);
    }

    [Fact]
    public void ActivePlayer_GetNrPointsScored_ReturnByte()
    {
        //Act
        var actualNrPointsScored1 = _activePlayer1.NrPointsScored;
        var actualNrPointsScored2 = _activePlayer2.NrPointsScored;
        
        //Assert
        Assert.Equal(NrPointsScored1, actualNrPointsScored1);
        Assert.Equal(NrPointsScored2, actualNrPointsScored2);
    }

    [Fact]
    public void ActivePlayer_GetActivePlayerType_ReturnActivePlayerType()
    {
        //Act
        var actualActivePlayerType1 = _activePlayer1.ActivePlayerType;
        var actualActivePlayerType2 = _activePlayer2.ActivePlayerType;
        
        //Assert
        Assert.Equal(ActivePlayerType1, actualActivePlayerType1);
        Assert.Equal(ActivePlayerType2, actualActivePlayerType2);
    }
}