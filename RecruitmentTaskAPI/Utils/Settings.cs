﻿using Microsoft.Extensions.Configuration;

namespace RecruitmentTaskAPI.Utils
{
    public class Settings
    {
        public static void Initialize(IConfiguration configuration)
        {
            FileLocation = configuration.GetValue<string>("FileLocation");
            FileName = configuration.GetValue<string>("FileName");
        }

        public static string FileLocation { get; private set; }
        public static string FileName { get; private set; }
    }
}
