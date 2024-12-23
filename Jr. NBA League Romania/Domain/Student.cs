namespace Jr._NBA_League_Romania.Domain;

public class Student(Guid id, string name, string school) : Entity<Guid>(id)
{
    public string Name { get; } = name;
    public string School { get; } = school;
}