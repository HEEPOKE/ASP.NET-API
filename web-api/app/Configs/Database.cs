using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace app.Configs;

public class Database
{
    private readonly string _connectionString;

    public Database()
    {
        _connectionString = Configs.AppConfigHelper.DB_CONNECT ?? "";
    }

    public async Task<IDbConnection> CreateConnectionAsync()
    {
        var connection = new NpgsqlConnection(_connectionString);
        try
        {
            await connection.OpenAsync();
            return connection;
        }
        catch (Exception ex)
        {
            connection.Dispose();
            throw new Exception("Failed to connect to database", ex);
        }
    }
}
