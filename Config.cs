using System.IO;
namespace Stationeers_Fixes_Package
{
    internal static class Plugin_Config
    {
        public const string ID = "SmallHy.Plugin.Fixes.Package";
        public const string Name = "Stationeers_Fixes_Package";
        public const string Version = "2.6.0.0";
    }
    internal class LocationConfig
    {
        public static string FontLocation1 = Path.Combine(Directory.GetParent(System.AppDomain.CurrentDomain.BaseDirectory).Parent.FullName, "workshop/content/544550/3560271413/GameData/Font/Microsoft_YaHei.ttc");
        public static string FontLocation2 = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "BepInEx/plugins/Stationeers-Fixes-Package/Font/Microsoft_YaHei.ttc");
    }
}
