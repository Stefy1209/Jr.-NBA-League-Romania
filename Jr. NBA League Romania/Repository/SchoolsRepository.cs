﻿using Jr._NBA_League_Romania.Domain;
using Npgsql;

namespace Jr._NBA_League_Romania.Repository;

public class SchoolsRepository : IRepository<Guid, School>
{
    private const string ConnString = "Host=localhost;Username=postgres;Password=1234;Database=Jr. NBA League Romania";
    
    public School? FindOne(Guid id)
    {
        if(id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        try
        {
            using var conn = Connect();
            
            using var cmd = new NpgsqlCommand("select name from \"Schools\" where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            using var reader = cmd.ExecuteReader();
            
            return !reader.Read() ? null : new School(id, reader.GetString(0));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public IEnumerable<School> FindAll()
    {
        try
        {
            using var conn = Connect();
            
            using var cmd = new NpgsqlCommand("select id, name from \"Schools\"", conn);
            using var reader = cmd.ExecuteReader();
            
            var list = new List<School>();
            
            while (reader.Read())
            {
                list.Add(new School(reader.GetGuid(0), reader.GetString(1)));
            }

            return list;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public School? Save(School? entity)
    {
        ArgumentNullException.ThrowIfNull(entity, nameof(entity));

        try
        {
            using var conn = Connect();

            using var cmd = new NpgsqlCommand("insert into \"Schools\" (id, name) values (@id, @name)", conn);
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

    public School? Delete(Guid id)
    {
        if (id == Guid.Empty) throw new ArgumentNullException(nameof(id));

        try
        {
            var school = FindOne(id);
            
            if(school == null) return null;
            
            using var conn = Connect();
            
            using var cmd = new NpgsqlCommand("delete from \"Schools\" where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            
            return cmd.ExecuteNonQuery() == 1 ? school : null;
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