// --------------------------------------------------------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Extensions
{
    using Framework.Core.Base;
    using Framework.Core.Classes;
    using Framework.Core.DataAnnotations;
    using Framework.Core.Globalization;
    #region usings

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Globalization;
    using System.Linq;

    #endregion

    /// <summary>
    ///     The enum extensions.
    /// </summary>
    public static class EnumExtensions
    {
        /// <summary>
        /// The has.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool Has<T>(this Enum type, T value)
        {
            try
            {
                return ((int)(object)type & (int)(object)value) == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// The is.
        /// </summary>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <param name="value">
        /// The value.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool Is<T>(this Enum type, T value)
        {
            try
            {
                return (int)(object)type == (int)(object)value;
            }
            catch
            {
                return false;
            }
        }



        public static EnumDescription GetDescriptionValues<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                var result = new EnumDescription();
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(LookupLocalizationAttribute), false)
                            .FirstOrDefault() as LookupLocalizationAttribute;


                        if (descriptionAttribute != null)
                        {
                            result.NameAr = descriptionAttribute.NameAr;
                            result.NameEn = descriptionAttribute.NameEn;
                            // return descriptionAttribute.NameAr; 
                        }
                    }
                }
            }

            return null;
        }

        public static (string nameAr, string nameEn) GetFullDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(LookupLocalizationAttribute), false)
                            .FirstOrDefault() as LookupLocalizationAttribute;


                        if (descriptionAttribute != null)
                        {
                            return (descriptionAttribute.NameAr, descriptionAttribute.NameEn);
                        }
                    }
                }
            }

            return ("", "");
        }

        public static string GetDescription<T>(this T e) where T : IConvertible
        {
            if (e is Enum)
            {
                Type type = e.GetType();
                Array values = Enum.GetValues(type);

                foreach (int val in values)
                {
                    if (val == e.ToInt32(CultureInfo.InvariantCulture))
                    {
                        var memInfo = type.GetMember(type.GetEnumName(val));
                        var descriptionAttribute = memInfo[0]
                            .GetCustomAttributes(typeof(LookupLocalizationAttribute), false)
                            .FirstOrDefault() as LookupLocalizationAttribute;


                        if (descriptionAttribute != null)
                        {
                            return CultureHelper.IsArabic ? descriptionAttribute.NameAr : descriptionAttribute.NameEn;
                            // return descriptionAttribute.NameAr; 
                        }
                    }
                }
            }

            return null;
        }

        public static List<LookupEntityBase> GetEnumLookupNamesAndDesc(this Type e)
        {
            Array values = Enum.GetValues(e);
            var list = new List<LookupEntityBase>();
            foreach (int val in values)
            {

                var memInfo = e.GetMember(e.GetEnumName(val));
                var descriptionAttribute = memInfo[0]
                    .GetCustomAttributes(typeof(DescriptionAttribute), false)
                    .FirstOrDefault() as DescriptionAttribute;
                var name = memInfo[0].Name;
                var desc = "";
                if (descriptionAttribute != null)
                {
                    desc = descriptionAttribute.Description;
                }
                list.Add(new LookupEntityBase(val, name, desc));

            }
            return list;
        }
        public static List<LookupEntityBase> GetEnumLookups(this Type e)
        {
            Array values = Enum.GetValues(e);
            var list = new List<LookupEntityBase>();
            foreach (int val in values)
            {

                var memInfo = e.GetMember(e.GetEnumName(val));
                var descriptionAttribute = memInfo[0]
                    .GetCustomAttributes(typeof(LookupLocalizationAttribute), false)
                    .FirstOrDefault() as LookupLocalizationAttribute;
                var nameAr = memInfo[0].Name;
                var nameEn = memInfo[0].Name;
                var value = memInfo[0].Name;
                if (descriptionAttribute != null)
                {
                    nameAr = descriptionAttribute.NameAr;
                    nameEn = descriptionAttribute.NameEn;
                }
                list.Add(new LookupEntityBase(val, nameAr, value, nameEn));

            }
            return list;
        }



    }
}

