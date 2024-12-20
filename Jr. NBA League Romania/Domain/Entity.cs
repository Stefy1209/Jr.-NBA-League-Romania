namespace Jr._NBA_League_Romania.Domain;

public class Entity<TId>(TId id)
{
    public TId Id { get; } = id;
}