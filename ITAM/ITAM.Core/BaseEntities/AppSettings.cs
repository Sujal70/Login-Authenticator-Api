using ConfigReader.Entities;

namespace LT.Core.BaseEntities
{

    /// <summary>
    /// This class is wrapper to get the all Appseting.json file attributes values and JWT Token Parsed values from NuGet Package
    /// </summary>
    public static class AppSettings
    {
        public static AppConfigurationModel AppConfig { get; set; }
        public static TokenClaimModel TokenClaimModel { get; set; }
    }
}
