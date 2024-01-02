using Framework.Core;
using Framework.Core.Caching;
using Framework.Core.CommonTables.Entities;
using Framework.Core.Contracts;
using Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Framework.Common.Services
{
    public class AppSettingsService : IAppSettingsService
    {
        private readonly CommonRepository<SystemSetting> settingRepository;
        private readonly ICacheManager _cacheManager;

        public AppSettingsService(CommonRepository<SystemSetting> settingRepository,
                                  ICacheManager cacheManager)
        {
            this.settingRepository = settingRepository;
            _cacheManager = cacheManager;
            LoadSettings();
        }

        public bool MockDate { get; set; }
        public bool MockUser { get; set; }
        public string ApplicationUrl { get; set; }
        public bool MockDataBase { get; set; }
        public string DBName { get; set; }
        public string ExternalUrl { get; set; }
        public string InternalUrl { get; set; }
        public string PortalUrl { get; set; }
        public string DateFormat { get; set; }
        public string DateTimeFormat => $"{DateFormat} {TimeFormat}";
        public int DefaultPagerPageSize { get; set; }
        public string PagerSizeDefaultValues { get; set; }
        public int ExportNoOfItems { get; set; }
        public string TimeFormat { get; set; }
        public string RequestDetailsPageUrl { get; set; }
        public DateTime CurrentDate { get; set; }
        public string ActiveDirectoryDomainName { get; set; }
        public int VerificationCodeMaxAttempts { get; set; }
        public int IdentityTokenLifespan { get; set; }
        public string K2WebApiUrl { get; set; }
        public string K2SecurityLabel { get; set; }
        public int SupportProgramExpiryInMonths { get; set; }

        public SettingsVM GetSetting(string key)
        {
            if (string.IsNullOrEmpty(key))
                return null;

            var settings = GetAllSettingsCached();

            key = key.Trim().ToLowerInvariant();

            if (!settings.ContainsKey(key))
                return null;

            var settingsByKey = settings[key];
            var setting = settingsByKey.FirstOrDefault(x => x.Name.ToLowerInvariant() == key);

            return setting;
        }

        protected IDictionary<string, IList<SettingsVM>> GetAllSettingsCached()
        {
            //cache
            return _cacheManager.Get(CachingDefaults.SettingsAllCacheKey, () =>
            {
                //we use no tracking here for performance optimization
                //anyway records are loaded only for read-only operations
                var query = from s in settingRepository.TableNoTracking
                            orderby s.Name
                            select s;
                var settings = query.ToList();
                var dictionary = new Dictionary<string, IList<SettingsVM>>();
                foreach (var s in settings)
                {
                    var resourceName = s.Name.ToLowerInvariant();

                    var settingForCaching = new SettingsVM
                    {
                        Id = s.Id,
                        Name = s.Name,
                        Value = s.Value,
                        GroupName = s.GroupName,
                        ValueType = s.ValueType
                    };

                    if (!dictionary.ContainsKey(resourceName))
                    {
                        //first setting
                        dictionary.Add(resourceName, new List<SettingsVM>
                        {
                            settingForCaching
                        });
                    }
                    else
                    {
                        //already added
                        //most probably it's the setting with the same name but for some certain store (storeId > 0)
                        dictionary[resourceName].Add(settingForCaching);
                    }
                }

                return dictionary;
            });
        }

        public List<SettingsVM> GetSettingsByGroup(string groupName)
        {
            var list = new List<SettingsVM>();


            foreach (var setting in GetAllSettingsCached())
            {
                var item = setting.Value.Where(a => a.GroupName == groupName);
                list.AddRange(item.ToList());
            }

            return list;
        }


        public virtual void UpdateSetting(SettingsVM settingsVM, bool clearCache = true)
        {
            if (settingsVM == null)
                throw new ArgumentNullException(nameof(settingsVM));

            var setting = settingRepository.GetById(settingsVM.Id);
            setting.Value = settingsVM.Value;
            settingRepository.Update(setting, true);

            //cache
            if (clearCache)
                _cacheManager.Remove(CachingDefaults.SettingsAllCacheKey);
        }

        public T GetValue<T>(string key, T defaultValue = default)
        {
            if (string.IsNullOrEmpty(key))
                return defaultValue;

            var settings = GetAllSettingsCached();

            key = key.Trim().ToLowerInvariant();

            if (!settings.ContainsKey(key))
                return defaultValue;

            var settingsByKey = settings[key];

            var setting = settingsByKey.FirstOrDefault(x => x.Name.ToLowerInvariant() == key);


            return setting != null ? CommonHelper.To<T>(setting.Value) : defaultValue;
        }

        private void LoadSettings()
        {

            foreach (var prop in GetType().GetProperties())
            {
                // get properties we can read and write to
                if (!prop.CanRead || !prop.CanWrite)
                    continue;

                var key = prop.Name;

                var setting = GetValue<string>(key);

                if (setting == null)
                    continue;

                if (!TypeDescriptor.GetConverter(prop.PropertyType).CanConvertFrom(typeof(string)))
                    continue;

                if (!TypeDescriptor.GetConverter(prop.PropertyType).IsValid(setting))
                    continue;

                var value = TypeDescriptor.GetConverter(prop.PropertyType).ConvertFromInvariantString(setting);

                //set property
                prop.SetValue(this, value);
            }

        }
    }
}
