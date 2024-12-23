using Jr._NBA_League_Romania.Domain;

namespace Jr._NBA_League_Romania.Tests.DomainTests;

public class EntityTests
{
    [Fact]
    public void Entity_GetId_ReturnTid()
    {
        //Arrange
        var entity = new Entity<int>(1);

        //Act
        var id = entity.Id;

        //Assert
        Assert.Equal(1, id);
    }
}