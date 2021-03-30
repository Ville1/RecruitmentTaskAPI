using Microsoft.Extensions.Configuration;

namespace RecruitmentTaskAPI.Utils
{
    public class Settings
    {
        public static void Initialize(IConfiguration configuration)
        {
            SaveLocation = configuration.GetValue<string>("SaveLocation");
            SaveFileName = configuration.GetValue<string>("SaveFileName");
        }

        public static string SaveLocation { get; private set; }
        public static string SaveFileName { get; private set; }
    }
}
