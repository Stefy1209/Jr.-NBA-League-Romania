namespace Jr._NBA_League_Romania.Domain;

public class Student(Guid id, string name, Guid idSchool) : Entity<Guid>(id)
{
    public string Name { get; } = name;
    public Guid School { get; } = idSchool;
}