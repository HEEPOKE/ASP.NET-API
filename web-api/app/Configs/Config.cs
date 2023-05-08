using Microsoft.Extensions.Configuration;
using System;

namespace app.Configs;

public class Config
{
    private readonly IConfiguration _configuration;

    public Config()
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .Build();
    }

    public string DB_CONNECT => GetEnvironmentVariable("DB_CONNECT");

    private string GetEnvironmentVariable(string key)
    {
        var value = _configuration?[key];
        if (string.IsNullOrEmpty(value))
        {
            value = Environment.GetEnvironmentVariable(key);
        }

        return value;
    }
}
