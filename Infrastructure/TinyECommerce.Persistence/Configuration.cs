using Microsoft.Extensions.Configuration;

namespace TinyECommerce.Persistence;

public static class Configuration
{
    private static ConfigurationManager _configurationManager;

    static Configuration()
    {
        _configurationManager = new ConfigurationManager();
        _configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/TinyECommerce.API"));
        _configurationManager.AddJsonFile("appsettings.json");
    }

    public static string PostgreSqlConnectionString
    {
        get
        {
            return _configurationManager.GetConnectionString("PostgreSQL") ?? "";
        }
    }
    
    public static string AllowedHosts
    {
        get
        {
            return _configurationManager.GetSection("AllowedHosts").Value ?? "*";
        }
    }
}