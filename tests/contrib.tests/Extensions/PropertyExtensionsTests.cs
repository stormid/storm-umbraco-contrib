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
        public void Only_TargetProperty_Is_Empty()
        {
            var targetProperty = "";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty);
            Assert.Null(result);
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
            var fallbackProperty = (string)null;
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty });
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void TargetProperty_Is_Not_Set_And_One_Fallback_Is_Set()
        {
            var targetProperty = (string)null;
            var fallbackProperty = "Here is a fallback property";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty });
            Assert.Equal(fallbackProperty, result);
        }

        [Fact]
        public void TargetProperty_Is_Not_Set_And_Two_Fallbacks_Both_Set()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = "Here is a first fallback property";
            var fallbackProperty2 = "Here is a second fallback property";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Equal(fallbackProperty1, result);
        }

        [Fact]
        public void TargetProperty_Is_Not_Set_And_Two_Fallbacks_Only_First_Set()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = "Here is a first fallback property";
            var fallbackProperty2 = (string)null;
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Equal(fallbackProperty1, result);
        }

        [Fact]
        public void TargetProperty_Is_Not_Set_And_Two_Fallbacks_Only_Second_Set()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = (string)null;
            var fallbackProperty2 = "Here is a second fallback property";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Equal(fallbackProperty2, result);
        }

        [Fact]
        public void TargetProperty_Is_Not_Set_And_Two_Fallbacks_Both_Unset()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = (string)null;
            var fallbackProperty2 = (string)null;
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Null(result);
        }

        [Fact]
        public void TargetProperty_Is_Set_And_Two_Fallbacks_Both_Not_Set_And_Default_Is_Set()
        {
            var targetProperty = "Here is a sample property";
            var fallbackProperty1 = (string)null;
            var fallbackProperty2 = (string)null;
            var defaultValue = "Here is a default value";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 }, defaultValue);
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void TargetProperty_Is_Set_And_Two_Fallbacks_First_Not_Set_And_Default_Is_Set()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = (string)null;
            var fallbackProperty2 = "Here is a second fallback property";
            var defaultValue = "Here is a default value";
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 }, defaultValue);
            Assert.Equal(fallbackProperty2, result);
        }

        [Fact]
        public void TargetProperty_Is_Set_And_Two_Fallbacks_Both_Not_Set_And_Default_Not_Set()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = (string)null;
            var fallbackProperty2 = (string)null;
            var defaultValue = (string)null;
            var result = PropertyExtensions.GetPropertyOrFallbacks(targetProperty, new[] { fallbackProperty1, fallbackProperty2 }, defaultValue);
            Assert.Null(result);
        }
    }
}
