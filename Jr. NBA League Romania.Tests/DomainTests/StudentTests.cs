using Jr._NBA_League_Romania.Domain;

namespace Jr._NBA_League_Romania.Tests.DomainTests;

public class StudentTests
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

    private readonly Student _student1 = new(Id1, Name1, School1);
    private readonly Student _student2 = new(Id2, Name2, School2);
    private readonly Student _student3 = new(Id3, Name3, School3);
    
    [Fact]
    public void Student_GetId_ReturnGuid()
    {
        //Act
        var expectedId1 = _student1.Id;
        var expectedId2 = _student2.Id;
        var expectedId3 = _student3.Id;
        
        //Assert
        Assert.Equal(Id1, expectedId1);
        Assert.Equal(Id2, expectedId2);
        Assert.Equal(Id3, expectedId3);
    }
    
    [Fact]
    public void Student_GetName_ReturnString()
    {
        //Act
        var expectedName1 = _student1.Name;
        var expectedName2 = _student2.Name;
        var expectedName3 = _student3.Name;
        
        //Assert
        Assert.Equal(Name1, expectedName1);
        Assert.Equal(Name2, expectedName2);
        Assert.Equal(Name3, expectedName3);
    }

    [Fact]
    public void Student_GetSchool_ReturnString()
    {
        //Act
        var expectedSchool1 = _student1.School;
        var expectedSchool2 = _student2.School;
        var expectedSchool3 = _student3.School;
        
        //Assert
        Assert.Equal(School1, expectedSchool1);
        Assert.Equal(School2, expectedSchool2);
        Assert.Equal(School3, expectedSchool3);
    }
}