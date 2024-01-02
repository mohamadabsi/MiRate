using Framework.Core.Data;
using Framework.Core.Globalization;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Framework.Core.Base
{
    [Serializable]
    public partial class EntityBase : IEntity
    {
        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
    }

    [Serializable]
    public partial class EntityBase<TKey> : EntityBase, IEntity<TKey>
    {
        public TKey Id { get; set; }

    }

   
    public partial class LookupEntityBaseNoAudit<TKey> : IEntity
    {
        public TKey Id { get; set; }
        public string? CreatedBy { get; set; }

        public DateTime? CreatedOn { get; set; }

        public string? UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }

    public interface ICascadeDelete
    {

    }


    public partial class FullAuditedEntityBase<TKey> : EntityBase<TKey>
    {


        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

       

    }

    public partial class FullAuditedEntityBase : EntityBase, IEntity
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedOn { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? UpdatedOn { get; set; }

    }



    [Serializable]
    public partial class LookupEntityBase<TKey> : FullAuditedEntityBase<TKey>
    {
        public string NameAr { get; set; }

        public string NameEn { get; set; }

        [NotMapped]
        public string LName => CultureHelper.IsArabic ? NameAr : NameEn;
    }
    public class LookupEntityBase:EntityBase
    {
        public LookupEntityBase()
        {

        }
        public LookupEntityBase(int val, string nameAr,string nameEn= "")
        {
            NameAr = nameAr;
            NameEn = nameEn;
            Id = val;
            CreatedBy = "Admin";
            IsDeleted = false;
            IsActive = true;
        }

        public LookupEntityBase(int val, string nameAr, string value , string nameEn = "" )
        {
            NameAr = nameAr;
            NameEn = nameEn;
            Value = value;
            Id = val;
            CreatedBy = "Admin";
            IsDeleted = false;
            IsActive = true;
        }

        public int Id { get;  set; }
        public string NameAr { get;  set; }
        public string Description { get;  set; }
        [NotMapped]
        public string Value { get; set; }
        public string NameEn { get;  set; }


        public string CreatedBy { get;  set; }

        public DateTime CreatedOn { get;  set; }
    }


    [Serializable]
    public partial class LookupEntityBase2<TKey> : FullAuditedEntityBase<TKey>
    {
        public LookupEntityBase2()
        {
            IsActive = true;
        }
        public string NameAr { get; set; }

        public string NameEn { get; set; }
    }

}
