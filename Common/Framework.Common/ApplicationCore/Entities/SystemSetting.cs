// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SystemSetting.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

using Framework.Core.Base;
using System;

namespace Framework.Core.CommonTables.Entities
{
    public class SystemSetting : FullAuditedEntityBase<int>
    {
        public SystemSetting()
        {
            this.IsActive = true;
            this.IsDeleted = false;
            this.CreatedOn = DateTime.Now;
        }
        public SystemSetting(int Id,string name, string valueType, string value, string groupName, bool isSecure, bool isSticky):this()
        {
            this.Id = Id;
            this.Name = name;
            this.ValueType = valueType;
            this.Value = value;
            this.GroupName = groupName;
            this.IsSecure = isSecure;
            this.IsSticky = isSticky;
            this.CreatedOn = new DateTime(2021, 05, 29, 0, 0, 0, 0, DateTimeKind.Unspecified);
        }

        public int? ApplicationId { get; set; }
        public string Name { get; set; }
        public string ValueType { get; set; }
        public string Value { get; set; }
        public string GroupName { get; set; }
        public bool IsSecure { get; set; }
        public bool IsSticky { get; set; }
    }
}