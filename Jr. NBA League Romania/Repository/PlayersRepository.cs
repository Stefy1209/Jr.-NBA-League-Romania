using Jr._NBA_League_Romania.Domain;
using Npgsql;

namespace Jr._NBA_League_Romania.Repository;

public class PlayersRepository : AbstractRepository<Guid, Player>
{
    public override Player? FindOne(Guid id)
    {
        if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        try
        {
            using var conn = GetConnection();
            
            using var cmd = new NpgsqlCommand("select name, id_team from \"Players\" where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            using var reader = cmd.ExecuteReader();

            return !reader.Read() ? null : new Player(id, reader.GetString(0), reader.GetGuid(1), reader.GetGuid(1));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override IEnumerable<Player> FindAll()
    {
        try
        {
            using var conn = GetConnection();
            
            using var cmd = new NpgsqlCommand("select id, name, id_team from \"Players\"", conn);
            
            using var reader = cmd.ExecuteReader();
            
            var list = new List<Player>();

            while (reader.Read())
            {
                var id = reader.GetGuid(0);
                var name = reader.GetString(1);
                var teamId = reader.GetGuid(2);
                
                list.Add(new Player(id, name, teamId, teamId));
            }

            return list;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override Player? Save(Player? entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        try
        {
            using var conn = GetConnection();

            using var cmd = new NpgsqlCommand("insert into \"Players\" (id, name, id_team) values (@id, @name, @id_team)", conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@name", entity.Name);
            cmd.Parameters.AddWithValue("@id_team", entity.TeamId);
            
            return cmd.ExecuteNonQuery() == 1 ? null : entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override Player? Delete(Guid id)
    {
        if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        try
        {
            var player = FindOne(id);
            
            if(player == null) return null;
            
            using var conn = GetConnection();
            
            using var cmd = new NpgsqlCommand("delete from \"Players\" where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            return cmd.ExecuteNonQuery() == 1 ? player : null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}