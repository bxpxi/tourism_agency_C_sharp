using System.Configuration;

namespace Clientt
{
    public static class Config
    {
        public static string Host => ConfigurationManager.AppSettings.Get("Host");
        public static int Port => int.Parse(ConfigurationManager.AppSettings.Get("Port"));
    }
}