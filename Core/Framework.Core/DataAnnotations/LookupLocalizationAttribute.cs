using System;

namespace Framework.Core.DataAnnotations
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class LookupLocalizationAttribute : Attribute
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool IsHide { get; set; }

        public LookupLocalizationAttribute(string nameAr, string nameEn)
        {
            NameAr = nameAr;
            NameEn = nameEn;
        }

        public LookupLocalizationAttribute(string nameAr, string nameEn,bool isHide)
        {
            NameAr = nameAr;
            NameEn = nameEn;
            IsHide = isHide;
        }
    }
}
