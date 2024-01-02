﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ObjectExtensions.cs" company="Usama Nada">
//   No Copyright .. Copy, Share, and Evolve.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Framework.Core.Extensions
{
    #region usings

    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Reflection;
    using System.Text.RegularExpressions;
    using Framework.Core.DataAnnotations;
    using FrameworkCore.Data.Model;
    using Newtonsoft.Json;

    #endregion

    /// <summary>
    ///     The object extensions.
    /// </summary>
    public static class ObjectExtensions
    {
        /// <summary>
        /// Converts the anonymous type object to the <c>Dictionary{string, object}</c> type object.
        /// </summary>
        /// <param name="attributes">
        /// Anonymous type object.
        /// </param>
        /// <returns>
        /// Returns the <c>Dictionary{string, object}</c> type object.
        /// </returns>
        public static IDictionary<string, object> ConvertAnonymousObjectToDictionary(object attributes)
        {
            var dictionary = new Dictionary<string, object>();
            if (attributes == null)
            {
                return dictionary;
            }

            dictionary = attributes.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
                .ToDictionary(pi => pi.Name, pi => pi.GetValue(attributes));
            return dictionary;
        }
        /// <summary>
        /// Converts the anonymous type object to the <c>Dictionary{string, object}</c> type object.
        /// </summary>
        /// <param name="attributes">
        /// Anonymous type object.
        /// </param>
        /// <returns>
        /// Returns the <c>Dictionary{string, object}</c> type object.
        /// </returns>
        public static Dictionary<string, bool> ConvertAnonymousObjectToDictionaryForRequired<T>(this T attributes)
        {
            if (attributes == null)
            {
                return null;
            }
            //var attr = memberInfo.GetAttribute<DisplayNameAttribute>(false);
            //if (attr == null)
            //{
            //    return memberInfo.Name;
            //}

            //return attr.DisplayName;
            var info = TypeDescriptor.GetProperties(typeof(T))
            .Cast<PropertyDescriptor>()
            .Where(p => p.Attributes.Cast<Attribute>().Any(a => a.GetType() == typeof(CompletionTrackableAttribute)))
            .ToDictionary(p => p.Name, p => !(p.GetValue(attributes) == null || p.GetValue(attributes) == default));
            return info;

        }
        public static ObjectCompletion GetListCompletionTracker<T>(this List<T> attribute, string title)
        {
            if (attribute == null || !attribute.Any())
            {
                return new ObjectCompletion { ObjectTitle = title, IsCompleted = false };
            }
            return new ObjectCompletion { ObjectTitle = title, IsCompleted = true };

        }
        public static ObjectCompletion GetCompletionTracker<T>(this T attribute, string title)
        {
            if (attribute == null)
                attribute = default(T);
            var props = attribute.ConvertAnonymousObjectToDictionaryForRequired<T>();
            var list = new List<PropertyCompletion>();
            if (props == null || !props.Any())
                return new ObjectCompletion();
            foreach (var item in props)
            {
                if (attribute != null)
                {
                    var prop = attribute.GetType().GetProperties().FirstOrDefault(x => x.Name == item.Key);
                    if (prop != null)
                    {
                        //var name = prop.GetCustomAttribute<DisplayAttribute>().GetName();

                        var name = prop.Name;

                        var isCompleted = item.Value;
                        var value = prop.GetValue(attribute);

                        if (value == null
                            || value == string.Empty 
                            || value == "" 
                            || value.ToString() == Guid.Parse("00000000-0000-0000-0000-000000000000").ToString()                          
                            || value.ToString().Trim() == DateTime.MinValue.ToString()
                            || value.ToString().Trim() == string.Empty)
                            isCompleted = false;
                        else if (prop.PropertyType.Name == typeof(Guid).Name)
                            isCompleted = (Guid)value != Guid.Empty;
                        else if (prop.PropertyType.Name == typeof(int).Name)
                            isCompleted = (int)value != 0;
                        else if (prop.PropertyType.Name == typeof(DateTime).Name)
                        {

                            if (DateTime.TryParse(value.ToString(), out DateTime date))
                                isCompleted = date.Date != DateTime.MinValue.Date;
                            else
                                isCompleted = false;
                        }
                        var completion = new PropertyCompletion
                        {
                            PropertyName = name,
                            IsCompleted = isCompleted
                        };
                        list.Add(completion);
                    }
                }
            }


            var generalInfoTracker = new ObjectCompletion
            {
                Name = title.Replace(" ", ""),
                ObjectTitle = title,
                PropertiesCompletion = list,
                IsCompleted = list.Count(p => p.IsCompleted) == list.Count,
                AllRequiredFieldCount = list.Count,
                CompletedFieldCount = list.Count(p => p.IsCompleted),
                NotCompletedFieldCount = list.Count(p => p.IsCompleted == false)

            };
            return generalInfoTracker;
        }
        /// <summary>
        /// The is null or default.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public static bool IsNullOrDefault<T>(this object obj)
        {
            if (obj == null)
            {
                return true;
            }

            if (Equals(obj, default(T)))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// The set property value from string.
        /// </summary>
        /// <param name="target">
        /// The target.
        /// </param>
        /// <param name="propertyName">
        /// The property name.
        /// </param>
        /// <param name="propertyValue">
        /// The property value.
        /// </param>
        public static void SetPropertyValueFromString(this object target, string propertyName, object propertyValue)
        {
            var oProp = target.GetType().GetProperty(propertyName);
            var tProp = oProp.PropertyType;

            // Nullable properties have to be treated differently, since we 
            // use their underlying property to set the value in the object
            if (tProp.IsGenericType && tProp.GetGenericTypeDefinition().Equals(typeof(Nullable<>)))
            {
                // if it's null, just set the value from the reserved word null, and return
                if (propertyValue == null)
                {
                    oProp.SetValue(target, null, null);
                    return;
                }

                // Get the underlying type property instead of the nullable generic
                tProp = new NullableConverter(oProp.PropertyType).UnderlyingType;
            }

            // use the converter to get the correct value
            oProp.SetValue(target, Convert.ChangeType(propertyValue, tProp), null);
        }

        /// <summary>
        /// The to.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        /// <exception cref="NotSupportedException">
        /// </exception>
        public static T To<T>(object obj, T defaultValue, Type type)
        {
            // Place convert to structures types here
            if (type == typeof(short))
            {
                short value;
                if (short.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(ushort))
            {
                ushort value;
                if (ushort.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(int))
            {
                int value;

                if (int.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(uint))
            {
                uint value;

                if (uint.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(long))
            {
                long value;
                if (long.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(ulong))
            {
                ulong value;
                if (ulong.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(float))
            {
                float value;
                if (float.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(double))
            {
                double value;
                if (double.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(decimal))
            {
                decimal value;
                if (decimal.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(bool))
            {
                bool value;
                if (bool.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(DateTime))
            {
                DateTime value;
                if (DateTime.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(DateTimeOffset))
            {
                DateTimeOffset value;
                if (DateTimeOffset.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(byte))
            {
                byte value;
                if (byte.TryParse(obj.ToString(), out value))
                {
                    return (T)(object)value;
                }

                return defaultValue;
            }

            if (type == typeof(Guid))
            {
                const string GuidRegEx =
                    @"^(\{{0,1}([0-9a-fA-F]){8}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){4}-([0-9a-fA-F]){12}\}{0,1})$";
                var regEx = new Regex(GuidRegEx);
                if (regEx.IsMatch(obj.ToString()))
                {
                    return (T)(object)new Guid(obj.ToString());
                }

                return defaultValue;
            }

            if (type.GetTypeInfo().IsEnum)
            {
                if (Enum.IsDefined(type, obj))
                {
                    return (T)Enum.Parse(type, obj.ToString());
                }

                return defaultValue;
            }

            throw new NotSupportedException($"Couldn't parse \"{obj}\" as {type} to Type \"{typeof(T)}\"");
        }

        /// <summary>
        /// The to.
        /// </summary>
        /// <param name="obj">
        /// The obj.
        /// </param>
        /// <param name="defaultValue">
        /// The default value.
        /// </param>
        /// <typeparam name="T">
        /// </typeparam>
        /// <returns>
        /// The <see cref="T"/>.
        /// </returns>
        public static T To<T>(this object obj, T defaultValue = default(T))
        {
            if (obj == null)
            {
                return defaultValue;
            }

            if (obj is T)
            {
                return (T)obj;
            }

            var type = typeof(T);

            // Place convert to reference types here
            if (type == typeof(string))
            {
                return (T)(object)obj.ToString();
            }

            var underlyingType = Nullable.GetUnderlyingType(type);

            if (underlyingType != null)
            {
                return To(obj, defaultValue, underlyingType);
            }

            return To(obj, defaultValue, type);
        }

        /// <summary>
        /// object the json string. using JSON.Net Library
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(o, JsonDotNetSerializer.SerializerSettings);
        }

        /// <summary>
        /// The to json.
        /// </summary>
        /// <param name="o">
        /// The o.
        /// </param>
        /// <param name="settings">
        /// The settings.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public static string ToJson(this object o, JsonSerializerSettings settings)
        {
            return JsonConvert.SerializeObject(o, settings);
        }

        /// <summary>
        /// Builds a dictionary from the object's properties
        /// </summary>
        /// <param name="o">
        /// </param>
        /// <returns>
        /// The <see cref="IDictionary"/>.
        /// </returns>
        public static IDictionary<string, object> ToPropertyDictionary(this object o)
        {
            return o?.GetType().GetProperties()
                .Select(p => new KeyValuePair<string, object>(p.Name, p.GetValue(o, null))).ToDictionary();
        }

        /// <summary>
        /// Used to simplify and beautify casting an object to a type. 
        /// </summary>
        /// <typeparam name="T">Type to be casted</typeparam>
        /// <param name="obj">Object to cast</param>
        /// <returns>Casted object</returns>
        public static T As<T>(this object obj)
            where T : class
        {
            return (T)obj;
        }

        /// <summary>
        /// Check if an item is in a list.
        /// </summary>
        /// <param name="item">Item to check</param>
        /// <param name="list">List of items</param>
        /// <typeparam name="T">Type of the items</typeparam>
        public static bool IsIn<T>(this T item, params T[] list)
        {
            return list.Contains(item);
        }

    }
}