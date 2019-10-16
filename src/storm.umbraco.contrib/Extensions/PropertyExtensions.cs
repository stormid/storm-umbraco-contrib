using System;
using System.Collections.Generic;
using System.Linq;

namespace storm.umbraco.contrib.Extensions
{
    public static class PropertyExtensions
    {
        /// <summary>
        /// A method which attempts to returned a target property if it has a value. If not, a fallback property is returned. If both target and the fallback have no value, then a default value is returned.
        /// </summary>
        /// <typeparam name="T">The type of property to be returned.</typeparam>
        /// <param name="targetProperty">The preferred property to be returned.</param>
        /// <param name="fallbackProperty">A fallback property to be used if the targetProperty is not set.</param>
        /// <param name="defaultValue">The default value to be returned if both the target and fallback properties are not set.</param>
        /// <param name="treatDefaultAsNull">Should default values be returned.</param>
        /// <returns>The targetProperty if it is set, the highest priority fallback property if it is set, or a default value.</returns>
        public static T WithFallback<T>(this T targetProperty, T fallbackProperty = default, T defaultValue = default, bool treatDefaultAsNull = false)
        {
            if (targetProperty.IsPropertyNotNullOrEmpty(treatDefaultAsNull))
            {
                return targetProperty;
            }

            if (fallbackProperty.IsPropertyNotNullOrEmpty(treatDefaultAsNull))
            {
                return fallbackProperty;
            }

            return EqualityComparer<T>.Default.Equals(defaultValue, default) ? default : defaultValue;
        }

        /// <summary>
        /// A method which attempts to returned a target property if it has a value. If not, fallback properties are tried in order and the first property with a value is returned. If both target and fallback properties have no value, then a default value is returned.
        /// </summary>
        /// <typeparam name="T">The type of property to be returned.</typeparam>
        /// <param name="targetProperty">The preferred property to be returned.</param>
        /// <param name="fallbackProperties">A series of fallbacks properties, in priority order, to be used if the targetProperty is not set.</param>
        /// <param name="defaultValue">The default value to be returned if both the target and fallback properties are not set.</param>
        /// <param name="treatDefaultAsNull">Should default values be returned</param>
        /// <returns>The targetProperty if it is set, the highest priority fallback property if it is set, or a default value.</returns>
        public static T WithFallbacks<T>(this T targetProperty, T[] fallbackProperties = null, T defaultValue = default(T), bool treatDefaultAsNull = false)
        {
            if (targetProperty.IsPropertyNotNullOrEmpty(treatDefaultAsNull))
            {
                return targetProperty;
            }

            if (fallbackProperties != null && fallbackProperties.Any())
            {
                foreach (var fallback in fallbackProperties)
                {
                    if (fallback.IsPropertyNotNullOrEmpty(treatDefaultAsNull))
                    {
                        return fallback;
                    }
                }
            }

            return EqualityComparer<T>.Default.Equals(defaultValue, default(T)) ? default(T) : defaultValue;
        }

        /// <summary>
        /// Checks a property is not null and not empty
        /// </summary>
        /// <typeparam name="T">The type of property to be checked.</typeparam>
        /// <param name="property">The property to be checked.</param>
        /// <param name="treatDefaultAsNull">Should default values be returned</param>
        /// <returns>Whether the property is not null and not empty</returns>
        private static bool IsPropertyNotNullOrEmpty<T>(this T property, bool treatDefaultAsNull)
        {
            if (typeof(T) == typeof(string))
            {
                return property != null && !string.IsNullOrEmpty((string)(object)property);
            }

            return property != null && treatDefaultAsNull && !property.Equals(default(T));
        }
    }
}