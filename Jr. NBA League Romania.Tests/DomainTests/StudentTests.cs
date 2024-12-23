using Jr._NBA_League_Romania.Domain;

namespace Jr._NBA_League_Romania.Tests.DomainTests;

public class StudentTests
{
    [Fact]
    public void Student_GetId_ReturnGuid()
    {
        //Arrange
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var id3 = Guid.NewGuid();
        
        const string name1 = "Name1";
        const string name2 = "Name2";
        const string name3 = "Name3";
        
        const string school1 = "School1";
        const string school2 = "School2";
        const string school3 = "School3";
        
        var student1 = new Student(id1, name1, school1);
        var student2 = new Student(id2, name2, school2);
        var student3 = new Student(id3, name3, school3);
        
        //Act
        var expectedId1 = student1.Id;
        var expectedId2 = student2.Id;
        var expectedId3 = student3.Id;
        
        //Assert
        Assert.Equal(id1, expectedId1);
        Assert.Equal(id2, expectedId2);
        Assert.Equal(id3, expectedId3);
    }
    
    [Fact]
    public void Student_GetName_ReturnString()
    {
        //Arrange
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var id3 = Guid.NewGuid();
        
        const string name1 = "Name1";
        const string name2 = "Name2";
        const string name3 = "Name3";
        
        const string school1 = "School1";
        const string school2 = "School2";
        const string school3 = "School3";
        
        var student1 = new Student(id1, name1, school1);
        var student2 = new Student(id2, name2, school2);
        var student3 = new Student(id3, name3, school3);
        
        //Act
        var expectedName1 = student1.Name;
        var expectedName2 = student2.Name;
        var expectedName3 = student3.Name;
        
        //Assert
        Assert.Equal(name1, expectedName1);
        Assert.Equal(name2, expectedName2);
        Assert.Equal(name3, expectedName3);
    }

    [Fact]
    public void Student_GetSchool_ReturnString()
    {
        //Arrange
        var id1 = Guid.NewGuid();
        var id2 = Guid.NewGuid();
        var id3 = Guid.NewGuid();
        
        const string name1 = "Name1";
        const string name2 = "Name2";
        const string name3 = "Name3";
        
        const string school1 = "School1";
        const string school2 = "School2";
        const string school3 = "School3";
        
        var student1 = new Student(id1, name1, school1);
        var student2 = new Student(id2, name2, school2);
        var student3 = new Student(id3, name3, school3);
        
        //Act
        var expectedSchool1 = student1.School;
        var expectedSchool2 = student2.School;
        var expectedSchool3 = student3.School;
        
        //Assert
        Assert.Equal(school1, expectedSchool1);
        Assert.Equal(school2, expectedSchool2);
        Assert.Equal(school3, expectedSchool3);
    }
}