using Newtonsoft.Json;
using RecruitmentTaskAPI.Data;
using System;
using System.IO;

namespace RecruitmentTaskAPI.Utils
{
    public class FileManager
    {
        public static void Save(EmailData data)
        {
            File.AppendAllText(
                string.Format(
                    "{0}/{1}",
                    Settings.SaveLocation,
                    string.Format(Settings.SaveFileName, DateTime.Now.ToString("ddMMyyyy"))
                ),
                string.Format(
                    "{0},{1}",
                    JsonConvert.SerializeObject(data),
                    Environment.NewLine
                )
            );
        }
    }
}
