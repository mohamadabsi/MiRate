// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NotificationTemplate.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Notifications.Entities
{
    using Framework.Core.Base;

    #region usings

    using System.ComponentModel.DataAnnotations.Schema;

    #endregion

 
    public class NotificationSetting:LookupEntityBase
    {
        public NotificationSetting()
        {

        }
        public NotificationSetting(int id,string name,string value,string applicationId="")
        {
            this.Id = id;
            this.NameEn = name;
            this.Key = name;
            this.Value = value;
            this.ApplicationId = applicationId;

        }

        public string Value { get; set; }
        public string ApplicationId { get; set; }
        public string Key { get; set; } 
      
    }
}