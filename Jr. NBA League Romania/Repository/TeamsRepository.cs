using Jr._NBA_League_Romania.Domain;
using Npgsql;

namespace Jr._NBA_League_Romania.Repository;

public class TeamsRepository : IRepository<Guid, Team>
{
    private const string ConnString = "Host=localhost;Username=postgres;Password=1234;Database=Jr. NBA League Romania";
    
    public Team? FindOne(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        try
        {
            using var conn = Connect();

            using var cmd = new NpgsqlCommand("select name from \"Teams\" where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            using var reader = cmd.ExecuteReader();
            
            return !reader.Read() ? null : new Team(id, reader.GetString(0));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<Team> FindAll()
    {
        try
        {
            using var conn = Connect();
            
            using var cmd = new NpgsqlCommand("select id, name from \"Teams\"", conn);
            using var reader = cmd.ExecuteReader();
            
            var list = new List<Team>();

            while (reader.Read())
            {
                list.Add(new Team(reader.GetGuid(0), reader.GetString(1)));
            }

            return list;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Team? Save(Team? entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        try
        {
            using var conn = Connect();

            using var cmd = new NpgsqlCommand("insert into \"Teams\" (id, name) values (@id, @name)", conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            
            return cmd.ExecuteNonQuery() == 1 ? null : entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public Team? Delete(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        try
        {
            var team = FindOne(id);
            
            if(team == null) return null;
            
            using var conn = Connect();
            
            using var cmd = new NpgsqlCommand("delete from \"Teams\" where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            return cmd.ExecuteNonQuery() == 1 ? team : null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    private static NpgsqlConnection Connect()
    {
        var conn = new NpgsqlConnection(ConnString);
        conn.Open();
        
        return conn;
    }
}