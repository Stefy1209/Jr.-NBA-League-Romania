using Jr._NBA_League_Romania.Domain;
using Npgsql;

namespace Jr._NBA_League_Romania.Repository;

public abstract class AbstractRepository<TId, TEntity> : IRepository<TId, TEntity> where TEntity : Entity<TId>
{
    private const string ConnString = "Host=localhost;Username=postgres;Password=1234;Database=Jr. NBA League Romania";

    protected static NpgsqlConnection GetConnection()
    {
        var connection = new NpgsqlConnection(ConnString);
        connection.Open();
        
        return connection;
    }

    public abstract TEntity? FindOne(TId? id);
    public abstract IEnumerable<TEntity> FindAll();
    public abstract TEntity? Save(TEntity? entity);
    public abstract TEntity? Delete(TId? id);
}