using System;
namespace Framework.Core.Contracts
{
    public interface IAppSettingsService
    {
        bool MockDate { get; set; }
        bool MockUser { get; set; }
        string ApplicationUrl { get; set; }
        bool MockDataBase { get; set; }
        string DBName{ get; set; }
        string ExternalUrl { get; set; }
        string InternalUrl { get; set; }
        string ActiveDirectoryDomainName { get; set; }
        DateTime CurrentDate { get; set; }
        string DateFormat { get; set; }
        string DateTimeFormat { get; }
        int DefaultPagerPageSize { get; set; }
        string TimeFormat { get; set; }
        int SupportProgramExpiryInMonths { get; set; }
        SettingsVM GetSetting(string key);
    }
}