namespace Jr._NBA_League_Romania.Domain;

public class Student(Guid id, string name, Guid schoolId) : Entity<Guid>(id)
{
    public string Name { get; } = name;
    public Guid SchoolId { get; } = schoolId;
}