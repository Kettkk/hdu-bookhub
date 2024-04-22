using System;
namespace bookHubServer.Tool
{
	public class ConfigureTool
	{
		public ConfigureTool()
		{
		}

		public static IConfiguration getConfig() {
            var basePath = AppContext.BaseDirectory;
            var configPath = Path.Combine(basePath, "ConfigFile/appsettings.json");
            var builder = new ConfigurationBuilder()
                .AddJsonFile(configPath, optional: false, reloadOnChange: false); // 设置为不可选
            return builder.Build();
        }
	}
}

