using Jr._NBA_League_Romania.Domain;

namespace Jr._NBA_League_Romania.Tests.DomainTests;

public class EntityTests
{
    [Fact]
    public void Entity_GetId_ReturnTid()
    {
        //Arrange
        var idExample = Guid.NewGuid();
        var entity1 = new Entity<int>(1);
        var entity2 = new Entity<Guid>(idExample);

        //Act
        var id1 = entity1.Id;
        var id2 = entity2.Id;

        //Assert
        Assert.Equal(1, id1);
        Assert.Equal(idExample, id2);
    }
}