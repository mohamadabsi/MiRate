using Microsoft.Extensions.Configuration;

namespace Framework.Core.Extensions
{
    public static class ConfiguarionExtensions
    {
        public static R GetMockSettings<R>(this IConfiguration configuration)
        {

            var mockingSection = configuration.GetSection("MockSettings");

            var mockSettings = mockingSection.Get<R>();

            return mockSettings;
        }
        public static MockSettings GetMockSettings(this IConfiguration configuration)
        {

            var mockingSection = configuration.GetSection("MockSettings");

            var mockSettings = mockingSection.Get<MockSettings>();

            return mockSettings;
        }



        public static bool MockDataBase(this IConfiguration configuration)
        {
            var mocksettings = configuration.GetMockSettings();

            if (mocksettings == null)
                return false;

            return mocksettings.MockDatabase;
        }



        public static bool MockCurrentUser(this IConfiguration configuration)
        {
            var mocksettings = configuration.GetMockSettings();

            if (mocksettings == null)
                return false;

            return mocksettings.MockCurrentUser;
        }

        
    }

    public class MockSettings
    {
        public bool MockUserCompanies { get; set; }
        public bool MockCurrentUser { get; set; }
        public bool MockDatabase { get; set; }
        public string DBName { get; set; }
    }
}
