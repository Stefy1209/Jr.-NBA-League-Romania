using Jr._NBA_League_Romania.Domain;
using Npgsql;

namespace Jr._NBA_League_Romania.Repository;

public class GamesRepository : AbstractRepository<Guid, Game>
{
    public override Game? FindOne(Guid id)
    {
        if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        try
        {
            using var conn = GetConnection();

            using var cmd = new NpgsqlCommand("select id_team1, id_team2, date from \"Games\" where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            using var reader = cmd.ExecuteReader();

            return !reader.Read() ? null : new Game(id, reader.GetGuid(0), reader.GetGuid(1), reader.GetDateTime(2).ToLocalTime());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override IEnumerable<Game> FindAll()
    {
        try
        {
            using var conn = GetConnection();
            
            using var cmd = new NpgsqlCommand("select id, id_team1, id_team2, date from \"Games\"", conn);
            
            using var reader = cmd.ExecuteReader();
            
            var list = new List<Game>();

            while (reader.Read())
            {
                var id = reader.GetGuid(0);
                var team1Id = reader.GetGuid(1);
                var team2Id = reader.GetGuid(2);
                var date = reader.GetDateTime(3).ToLocalTime();
                
                list.Add(new Game(id, team1Id, team2Id, date));
            }

            return list;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }    
    }

    public override Game? Save(Game? entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        try
        {
            using var conn = GetConnection();
            
            using var cmd = new NpgsqlCommand("insert into \"Games\" (id, id_team1, id_team2, date) values (@id, @id_team1, @id_team2, @date)", conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@id_team1", entity.IdTeam1);
            cmd.Parameters.AddWithValue("@id_team2", entity.IdTeam2);
            cmd.Parameters.AddWithValue("@date", entity.DateTime.ToUniversalTime());
            
            return cmd.ExecuteNonQuery() == 1 ? null : entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override Game? Delete(Guid id)
    {
        try
        {
            var game = FindOne(id);
            
            if(game == null) return null;
            
            using var conn = GetConnection();
            
            using var cmd = new NpgsqlCommand("delete from \"Games\" where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            return cmd.ExecuteNonQuery() == 1 ? game : null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}