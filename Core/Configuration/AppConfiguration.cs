using Microsoft.Extensions.Configuration;

namespace Core.Configuration
{
    public class AppConfiguration
    {
        public static BrowserConfiguration Browser => BindConfiguration<BrowserConfiguration>();
        private static IConfigurationRoot configurationRoot;

        static AppConfiguration()
        {
            configurationRoot = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("Runsettings\\appsettings.json", optional: true, reloadOnChange: true)
                .Build();
        }

        private static T BindConfiguration<T>() where T : IConfiguration, new()
        {
            var config = new T();
            configurationRoot.GetSection(config.SectionName).Bind(config);
            return config;
        }

        public static string GetValue(string key)
        {
            return configurationRoot[key];
        }
    }
}
