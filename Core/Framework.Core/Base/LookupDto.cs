using Framework.Core.DataAnnotations;
using Framework.Core.Extensions;
using Framework.Core.Globalization;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Framework.Core.Base
{
    public class LookupVM
    {
        public bool HasParent { get; set; }
        public string Parent { get; set; }

        [DisplayName("Parent")]
        public int ParentId { get; set; }

        public string MessageAr { get; set; }
        public string MessageEn { get; set; }

        [Description("Name")]
        public string Text { get; set; }

        public string Value { get; set; }

        public bool IsSelected { get; set; }

        public List<LookupVM> ParentList { get; set; }
        public string TextAr { get; set; }

        public string LText => CultureHelper.IsArabic ? TextAr : Text;

        public LookupVM()
        {
                
        }

        public LookupVM(string value, string text, string textAr)
        {
            this.Text = text;
            this.Value = value;
            this.TextAr = textAr;
        }

        public LookupVM(string value, string text, string textAr  , string messageEn ,string messageAr )
        {
            this.Text = text;
            this.Value = value;
            this.TextAr = textAr;
        }

        public LookupVM(string value, string text)
        {
            this.Text = text;
            this.Value = value;
            this.TextAr = text;
        }

        public override bool Equals(object obj)
        {
            return obj.GetHashCode()==this.GetHashCode();
        }


        //public override string GetHashCode()
        //{
        //    return this.Value;
        //}




        public override string ToString()
        {
            return base.ToString();
        }
    }


    public static class BaseViewModelExtension
    {
        public static List<LookupVM> ToLookupList<T>(this List<T> list, bool removeSelectOptions) where T : LookupEntityBase
        {
            if (list == null || !list.Any())
                return new List<LookupVM>();

            var items = list.Select(l => new LookupVM
            {
                Text = l.NameAr,
                Value = l.Id.ToString()
            }).ToList();

            if (!removeSelectOptions)
            {
                items.Insert(0, new LookupVM { Text = "Choose", Value = "" });
            }

            return items;
        }

        public static List<SelectListItem> ToSelectItemsList(this List<LookupVM> list)
        {
            if (list == null || !list.Any())
                return new List<SelectListItem>();
            var items = list.Select(l => new SelectListItem
            {
                Text = l.Text,
                Value = l.Value
            }).ToList();
          
            items.Insert(0, new SelectListItem { Text = "Choose", Value = "" });
            return items;
        }
        public static List<SelectListItem> ToSelectItemsList(this List<LookupVM> list, bool removeSelectOptions,bool removeOther)
        {
            if (list == null || !list.Any())
                return new List<SelectListItem>();
            var items = list.Where(i=>!i.Text.Contains("Other")).Select(l => new SelectListItem
            {
                Text = l.Text,
                Value = l.Value
            }).ToList();
            if (!removeSelectOptions)
            {
                items.Insert(0, new SelectListItem { Text = "Choose", Value = "" });
            }
            return items;
        }
        public static List<SelectListItem> ToSelectItemsList(this List<LookupVM> list, bool removeSelectOptions)
        {
            if (list == null || !list.Any())
                return new List<SelectListItem>();
            var items = list.Select(l => new SelectListItem
            {
                Text = l.Text,
                Value = l.Value
            }).ToList();
            if (!removeSelectOptions)
            {
                items.Insert(0, new SelectListItem { Text = "Choose", Value = "" });
            }
            return items;
        }
        public static List<SelectListItem> ToSelectItemsList<T>(this List<T> list,string valueField ,string textField)
        {
            if (list == null || !list.Any())
                return new List<SelectListItem>();
            var items = new List<SelectListItem>();

            foreach (var item in list)
            {
                var textProp = item.GetType().GetProperties().FirstOrDefault(x => x.Name == textField);
                var text = textProp.GetValue(item);
                var idProp = item.GetType().GetProperties().FirstOrDefault(x => x.Name == valueField);
                var value = idProp.GetValue(item);
                items.Insert(0, new SelectListItem { Text = text.ToString(), Value = value.ToString() });
            }
            items.Insert(0, new SelectListItem { Text = "Choose", Value = "" });
            return items;
        }

        public static List<SelectListItem> ToSelectItemsList<T>(this List<T> list)
        {
            if (list == null || !list.Any())
                return new List<SelectListItem>();
            var items = new List<SelectListItem>();

            foreach (var item in list)
            {
                var textProp = item.GetType().GetProperties().FirstOrDefault(x => x.Name == "Text");
                if(textProp==null)
                {
                    textProp = item.GetType().GetProperties().FirstOrDefault(x => x.Name == "Name");
                }
                var text = textProp.GetValue(item);
                var idProp = item.GetType().GetProperties().FirstOrDefault(x => x.Name == "Id");
                var value = idProp.GetValue(item);
                items.Insert(0, new SelectListItem { Text = text.ToString(), Value = value.ToString() });
            }
            items = items.OrderBy(x => x.Text).ToList();
            items.Insert(0, new SelectListItem { Text = "Choose", Value = "" });
            return items;
        }

 
        public static RadioButtonList ToRadioButtonList<T>(this List<T> list)
        {
            if (list == null || !list.Any())
                return null;
            var radList = new RadioButtonList(list, "Id", "Text", 100);
            return radList;
        }
      
        public static RadioButtonList ToRadioButtonList(this List<LookupVM> list)
        {
            if (list == null || !list.Any())
                return null;
            return new RadioButtonList(list, "Value", "Text", 100);
        }

        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                         select new { Id = e, Name = e.ToString() };
            return new SelectList(values, "Id", "Name", enumObj);
        }
        public static string ToYesNoString(this bool value)
        {
            return value ? "Yes" :"No";
        }

        public static List<LookupVM> ToLookups(this Type e)
        {
            Array values = Enum.GetValues(e);

            var list = new List<LookupVM>();

            foreach (int val in values)
            {
                var memInfo = e.GetMember(e.GetEnumName(val));

                var descriptionAttribute = memInfo[0]
                    .GetCustomAttributes(typeof(LookupLocalizationAttribute), false)
                    .FirstOrDefault() as LookupLocalizationAttribute;

                var name = memInfo[0].Name;

                if (descriptionAttribute != null)
                {
                    name = CultureHelper.IsArabic? descriptionAttribute.NameAr:descriptionAttribute.NameEn;
                }

                list.Add(new LookupVM(val.ToString(), name));

            }

            return list;
        }
    }
}
