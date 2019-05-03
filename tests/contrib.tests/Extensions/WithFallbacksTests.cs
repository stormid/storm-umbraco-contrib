using System;
using storm.umbraco.contrib.Extensions;
using Xunit;

namespace contrib.tests.Extensions
{
    public class WithFallbacksTests
    {
        [Fact]
        public void String_Only_TargetProperty_Is_Set()
        {
            var targetProperty = "Here is a sample property";
            var result = targetProperty.WithFallbacks();
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void String_Only_TargetProperty_Is_Default()
        {
            var targetProperty = default(string);
            var result = targetProperty.WithFallbacks();
            Assert.Null(result);
        }

        [Fact]
        public void String_TargetProperty_Is_Set_And_One_Fallback_Is_Set()
        {
            var targetProperty = "Here is a sample property";
            var fallbackProperty = "Here is a fallback property";
            var result = targetProperty.WithFallbacks(new[] { fallbackProperty });
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void String_TargetProperty_Is_Set_And_One_Fallback_Is_Null()
        {
            var targetProperty = "Here is a sample property";
            var fallbackProperty = (string)null;
            var result = targetProperty.WithFallbacks(new[] { fallbackProperty });
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void String_TargetProperty_Is_Null_And_One_Fallback_Is_Set()
        {
            var targetProperty = "";
            var fallbackProperty = "Here is a fallback property";
            var result = targetProperty.WithFallbacks(new[] { fallbackProperty });
            Assert.Equal(fallbackProperty, result);
        }

        [Fact]
        public void String_TargetProperty_Is_Null_And_Two_Fallbacks_Both_Set()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = "Here is a first fallback property";
            var fallbackProperty2 = "Here is a second fallback property";
            var result = targetProperty.WithFallbacks(new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Equal(fallbackProperty1, result);
        }

        [Fact]
        public void String_TargetProperty_Is_Null_And_Two_Fallbacks_Only_First_Set()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = "Here is a first fallback property";
            var fallbackProperty2 = (string)null;
            var result = targetProperty.WithFallbacks(new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Equal(fallbackProperty1, result);
        }

        [Fact]
        public void String_TargetProperty_Is_Null_And_Two_Fallbacks_Only_Second_Set()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = (string)null;
            var fallbackProperty2 = "Here is a second fallback property";
            var result = targetProperty.WithFallbacks(new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Equal(fallbackProperty2, result);
        }

        [Fact]
        public void String_TargetProperty_Is_Null_And_Two_Fallbacks_Both_Null()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = (string)null;
            var fallbackProperty2 = (string)null;
            var result = targetProperty.WithFallbacks(new[] { fallbackProperty1, fallbackProperty2 });
            Assert.Null(result);
        }

        [Fact]
        public void String_TargetProperty_Is_Set_And_Two_Fallbacks_Both_Null_And_Default_Is_Set()
        {
            var targetProperty = "Here is a sample property";
            var fallbackProperty1 = (string)null;
            var fallbackProperty2 = (string)null;
            var defaultValue = "Here is a default value";
            var result = targetProperty.WithFallbacks(new[] { fallbackProperty1, fallbackProperty2 }, defaultValue);
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void String_TargetProperty_Is_Null_And_Two_Fallbacks_First_Null_And_Default_Is_Set()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = (string)null;
            var fallbackProperty2 = "Here is a second fallback property";
            var defaultValue = "Here is a default value";
            var result = targetProperty.WithFallbacks(new[] { fallbackProperty1, fallbackProperty2 }, defaultValue);
            Assert.Equal(fallbackProperty2, result);
        }

        [Fact]
        public void String_TargetProperty_Is_Null_And_Two_Fallbacks_Both_Null_Set_And_Default_Null()
        {
            var targetProperty = (string)null;
            var fallbackProperty1 = (string)null;
            var fallbackProperty2 = (string)null;
            var defaultValue = (string)null;
            var result = targetProperty.WithFallbacks(new[] { fallbackProperty1, fallbackProperty2 }, defaultValue);
            Assert.Null(result);
        }

        [Fact]
        public void Int_TargetProperty_Is_Default_And_One_Fallback_Is_Set()
        {
            var targetProperty = default(int);
            var fallback = 25;
            var result = targetProperty.WithFallbacks(new[] { fallback });
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void Int_TargetProperty_Is_Default_And_One_Fallback_Is_Set_Treat_Default_As_Null()
        {
            var targetProperty = default(int);
            var fallback = 25;
            var result = targetProperty.WithFallbacks(new[] { fallback }, treatDefaultAsNull: true);
            Assert.Equal(fallback, result);
        }

        [Fact]
        public void Double_TargetProperty_Is_Default_And_One_Fallback_Is_Set()
        {
            var targetProperty = default(double);
            var fallback = 24.99;
            var result = targetProperty.WithFallbacks(new[] { fallback });
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void Double_TargetProperty_Is_Default_And_One_Fallback_Is_Set_Treat_Default_As_Null()
        {
            var targetProperty = default(double);
            var fallback = 24.99;
            var result = targetProperty.WithFallbacks(new[] { fallback }, treatDefaultAsNull: true);
            Assert.Equal(fallback, result);
        }

        [Fact]
        public void Boolean_TargetProperty_Is_Default_And_One_Fallback_Is_Set()
        {
            var targetProperty = default(bool);
            var fallback = true;
            var result = targetProperty.WithFallbacks(new[] { fallback });
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void Boolean_TargetProperty_Is_Default_And_One_Fallback_Is_Set_Set_Treat_Default_As_Null()
        {
            var targetProperty = default(bool);
            var fallback = true;
            var result = targetProperty.WithFallbacks(new[] { fallback }, treatDefaultAsNull: true);
            Assert.Equal(fallback, result);
        }

        [Fact]
        public void Date_TargetProperty_Is_Default_And_One_Fallback_Is_Set()
        {
            var targetProperty = default(DateTime);
            var fallback = DateTime.Now;
            var result = targetProperty.WithFallbacks(new[] { fallback }, treatDefaultAsNull: true);
            Assert.Equal(fallback, result);
        }

        [Fact]
        public void Date_TargetProperty_Is_Default_And_One_Fallback_Is_Set_Treat_Default_As_Null()
        {
            var targetProperty = default(DateTime);
            var fallback = DateTime.Now;
            var result = targetProperty.WithFallbacks(new[] { fallback });
            Assert.Equal(targetProperty, result);
        }
    }
}