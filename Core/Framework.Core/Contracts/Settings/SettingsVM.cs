using Framework.Core.Resources;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace Framework.Core.Contracts
{
    [Serializable]
    public class SettingsVM
    {
        [HiddenInput]
        public int Id { get; set; }

        [Display(Name = "SettingName", ResourceType = typeof(CommonMessages))]
        public string Name { get; set; }

        public string ValueType { get; set; }

        [Display(Name = "SettingValue", ResourceType = typeof(CommonMessages))]
        [Required]
        public string Value { get; set; }

        public string GroupName { get; set; }


    }
}
