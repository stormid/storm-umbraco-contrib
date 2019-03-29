using System.Collections.Generic;
using System.Linq;

namespace storm.umbraco.contrib.Extensions
{
    public static class PropertyExtensions
    {
        /// <summary>
        /// A method which attempts to returned a target property if it has a value. If not, fallback properties are tried in order and the first property with a value is returned. If both target and fallback properties have no value, then a default value is returned.
        /// </summary>
        /// <typeparam name="T">The type of property to be returned.</typeparam>
        /// <param name="targetProperty">The preferred property to be returned.</param>
        /// <param name="fallbackProperties">A series of fallbacks properties, in priority order, to be used if the targetProperty is not set.</param>
        /// <param name="defaultValue">The default value to be returned if both the target and fallback properties are not set.</param>
        /// <returns>The targetProperty if it is set, the highest priority fallback property if it is set, or a default value.</returns>
        public static T GetPropertyOrFallbacks<T>(this T targetProperty, T[] fallbackProperties = null, T defaultValue = default(T))
        {
            if (targetProperty != null && !targetProperty.Equals(default(T)))
            {
                return targetProperty;
            }

            if (fallbackProperties != null && fallbackProperties.Any())
            {
                foreach (var fallback in fallbackProperties)
                {
                    if (fallback != null && !fallback.Equals(default(T)))
                    {
                        return fallback;
                    }
                }
            }

            return EqualityComparer<T>.Default.Equals(defaultValue, default(T)) ? default(T) : defaultValue;
        }
    }
}