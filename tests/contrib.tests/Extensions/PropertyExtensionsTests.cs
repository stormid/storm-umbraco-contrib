using storm.umbraco.contrib.Extensions;
using Xunit;

namespace contrib.tests.Extensions
{
    public class PropertyExtensionsTests
    {
        [Fact]
        public void Only_TargetProperty_Is_Set()
        {
            var targetProperty = "Here is a sample property";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty);
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void TargetProperty_Is_Set_And_One_Fallback_Is_Set()
        {
            var targetProperty = "Here is a sample property";
            var fallbackProperty = "Here is a fallback property";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty });
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void TargetProperty_Is_Set_And_One_Fallback_Is_Not_Set()
        {
            var targetProperty = "Here is a sample property";
            var fallbackProperty = default(string);
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty });
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void TargetProperty_Is_Not_Set_And_One_Fallback_Is_Set()
        {
            var targetProperty = default(string);
            var fallbackProperty = "Here is a fallback property";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty });
            Assert.Equal(fallbackProperty, result);
        }

        [Fact]
        public void TargetProperty_Is_Not_Set_And_Two_Fallbacks_Both_Set()
        {
            var targetProperty = default(string);
            var fallbackProperty1 = "Here is a first fallback property";
            var fallbackProperty2 = "Here is a second fallback property";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Equal(fallbackProperty1, result);
        }

        [Fact]
        public void TargetProperty_Is_Not_Set_And_Two_Fallbacks_Only_First_Set()
        {
            var targetProperty = default(string);
            var fallbackProperty1 = "Here is a first fallback property";
            var fallbackProperty2 = default(string);
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Equal(fallbackProperty1, result);
        }

        [Fact]
        public void TargetProperty_Is_Not_Set_And_Two_Fallbacks_Only_Second_Set()
        {
            var targetProperty = default(string);
            var fallbackProperty1 = default(string);
            var fallbackProperty2 = "Here is a second fallback property";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Equal(fallbackProperty2, result);
        }

        [Fact]
        public void TargetProperty_Is_Not_Set_And_Two_Fallbacks_Both_Unset()
        {
            var targetProperty = default(string);
            var fallbackProperty1 = default(string);
            var fallbackProperty2 = default(string);
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Equal(default(string), result);
        }

        [Fact]
        public void TargetProperty_Is_Set_And_Two_Fallbacks_Both_Not_Set_And_Default_Is_Set()
        {
            var targetProperty = "Here is a sample property";
            var fallbackProperty1 = default(string);
            var fallbackProperty2 = default(string);
            var defaultValue = "Here is a default value";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 }, defaultValue);
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void TargetProperty_Is_Set_And_Two_Fallbacks_First_Not_Set_And_Default_Is_Set()
        {
            var targetProperty = default(string);
            var fallbackProperty1 = default(string);
            var fallbackProperty2 = "Here is a second fallback property";
            var defaultValue = "Here is a default value";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 }, defaultValue);
            Assert.Equal(fallbackProperty2, result);
        }

        [Fact]
        public void TargetProperty_Is_Set_And_Two_Fallbacks_Both_Not_Set_And_Default_Not_Set()
        {
            var targetProperty = default(string);
            var fallbackProperty1 = default(string);
            var fallbackProperty2 = default(string);
            var defaultValue = default(string);
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 }, defaultValue);
            Assert.Equal(default(string), result);
        }
    }
}
