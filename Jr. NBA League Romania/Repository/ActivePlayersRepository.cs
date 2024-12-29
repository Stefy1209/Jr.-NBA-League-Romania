using Jr._NBA_League_Romania.Domain;
using Npgsql;

namespace Jr._NBA_League_Romania.Repository;

public class ActivePlayersRepository : AbstractRepository<Guid, ActivePlayer>
{
    public override ActivePlayer? FindOne(Guid id)
    {
        if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        try
        {
            using var conn = GetConnection();
            
            using var cmd = new NpgsqlCommand("select id_player, id_game, nr_points_scored, type from \"ActivePlayers\" where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            using var reader = cmd.ExecuteReader();

            return !reader.Read() ? null : new ActivePlayer(id, reader.GetGuid(0), reader.GetGuid(1), reader.GetByte(2), (ActivePlayerType)reader.GetInt32(3));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override IEnumerable<ActivePlayer> FindAll()
    {
        try
        {
            using var conn = GetConnection();
            
            using var cmd = new NpgsqlCommand("select id, id_player, id_game, nr_points_scored, type from \"ActivePlayers\"", conn);
            
            using var reader = cmd.ExecuteReader();
            
            var list = new List<ActivePlayer>();

            while (reader.Read())
            {
                var id = reader.GetGuid(0);
                var playerId = reader.GetGuid(1);
                var gameId = reader.GetGuid(2);
                var nrPointsScored = reader.GetByte(3);
                var type = (ActivePlayerType)reader.GetInt32(4);
                
                list.Add(new ActivePlayer(id, playerId, gameId, nrPointsScored, type));
            }
            
            return list;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override ActivePlayer? Save(ActivePlayer? entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        try
        {
            using var conn = GetConnection();
            
            using var cmd = new NpgsqlCommand("insert into \"ActivePlayers\" (id, id_player, id_game, nr_points_scored, type) values (@id, @playerId, @gameId, @nrPointsScored, @type)", conn);
            cmd.Parameters.AddWithValue("@id", entity.Id);
            cmd.Parameters.AddWithValue("@playerId", entity.PlayerId);
            cmd.Parameters.AddWithValue("@gameId", entity.GameId);
            cmd.Parameters.AddWithValue("@nrPointsScored", entity.NrPointsScored);
            cmd.Parameters.AddWithValue("@type", (int)entity.ActivePlayerType);
            
            return cmd.ExecuteNonQuery() == 1 ? null : entity;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public override ActivePlayer? Delete(Guid id)
    {
        if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        try
        {
            var activePlayer = FindOne(id);
            
            if(activePlayer == null) return null;
            
            using var conn = GetConnection();
            
            using var cmd = new NpgsqlCommand("delete from \"ActivePlayers\" where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            return cmd.ExecuteNonQuery() == 1 ? activePlayer : null;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}