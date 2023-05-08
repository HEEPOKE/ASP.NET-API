using Microsoft.Extensions.Configuration;
using System;

namespace app.Configs;

public class AppConfig
{
    public string? DB_CONNECT { get; set; }
}

public static class AppConfigHelper
{
    private static readonly IConfiguration _configuration;
    private static readonly AppConfig _appConfig;

    static AppConfigHelper()
    {
        _configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true)
            .Build();

        _appConfig = new AppConfig
        {
            DB_CONNECT = _configuration["DB_CONNECT"],
        };
    }
    public static string? DB_CONNECT => _appConfig.DB_CONNECT;
}
