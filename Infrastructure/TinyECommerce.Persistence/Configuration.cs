using Microsoft.Extensions.Configuration;

namespace TinyECommerce.Persistence;

static class Configuration
{
    public static string PostgreSqlConnectionString
    {
        get
        {
            ConfigurationManager configurationManager = new();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/TinyECommerce.API"));
            configurationManager.AddJsonFile("appsettings.json");
            return configurationManager.GetConnectionString("PostgreSQL");
        }
    }
}