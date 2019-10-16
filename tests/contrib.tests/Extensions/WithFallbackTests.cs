using storm.umbraco.contrib.Extensions;
using System;
using Xunit;

namespace Contrib.Tests.Extensions
{
    public class WithFallbackTests
    {
        [Fact]
        public void String_Only_TargetProperty_Is_Set()
        {
            const string targetProperty = "Here is a sample property";
            var result = targetProperty.WithFallback();
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void String_Only_TargetProperty_Is_Default()
        {
            const string targetProperty = default(string);
            var result = targetProperty.WithFallback();
            Assert.Null(result);
        }

        [Fact]
        public void String_TargetProperty_Is_Set_And_One_Fallback_Is_Set()
        {
            const string targetProperty = "Here is a sample property";
            const string fallbackProperty = "Here is a fallback property";
            var result = targetProperty.WithFallback(fallbackProperty);
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void String_TargetProperty_Is_Set_And_One_Fallback_Is_Null()
        {
            const string targetProperty = "Here is a sample property";
            const string fallbackProperty = (string)null;
            var result = targetProperty.WithFallback(fallbackProperty);
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void String_TargetProperty_Is_Null_And_One_Fallback_Is_Set()
        {
            const string targetProperty = "";
            const string fallbackProperty = "Here is a fallback property";
            var result = targetProperty.WithFallback(fallbackProperty);
            Assert.Equal(fallbackProperty, result);
        }

        [Fact]
        public void Int_TargetProperty_Is_Default_And_One_Fallback_Is_Set()
        {
            const int targetProperty = default;
            const int fallback = 25;
            var result = targetProperty.WithFallback(fallback);
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void Int_TargetProperty_Is_Default_And_One_Fallback_Is_Set_Treat_Default_As_Null()
        {
            const int targetProperty = default;
            const int fallback = 25;
            var result = targetProperty.WithFallback(fallback, treatDefaultAsNull: true);
            Assert.Equal(fallback, result);
        }

        [Fact]
        public void Double_TargetProperty_Is_Default_And_One_Fallback_Is_Set()
        {
            const double targetProperty = default;
            const double fallback = 24.99;
            var result = targetProperty.WithFallback(fallback);
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void Double_TargetProperty_Is_Default_And_One_Fallback_Is_Set_Treat_Default_As_Null()
        {
            const double targetProperty = default;
            const double fallback = 24.99;
            var result = targetProperty.WithFallback(fallback, treatDefaultAsNull: true);
            Assert.Equal(fallback, result);
        }

        [Fact]
        public void Boolean_TargetProperty_Is_Default_And_One_Fallback_Is_Set()
        {
            const bool targetProperty = default;
            const bool fallback = true;
            var result = targetProperty.WithFallback(fallback);
            Assert.Equal(targetProperty, result);
        }

        [Fact]
        public void Boolean_TargetProperty_Is_Default_And_One_Fallback_Is_Set_Set_Treat_Default_As_Null()
        {
            const bool targetProperty = default;
            const bool fallback = true;
            var result = targetProperty.WithFallback(fallback, treatDefaultAsNull: true);
            Assert.Equal(fallback, result);
        }

        [Fact]
        public void Date_TargetProperty_Is_Default_And_One_Fallback_Is_Set()
        {
            var targetProperty = default(DateTime);
            var fallback = DateTime.Now;
            var result = targetProperty.WithFallback(fallback, treatDefaultAsNull: true);
            Assert.Equal(fallback, result);
        }

        [Fact]
        public void Date_TargetProperty_Is_Default_And_One_Fallback_Is_Set_Treat_Default_As_Null()
        {
            var targetProperty = default(DateTime);
            var fallback = DateTime.Now;
            var result = targetProperty.WithFallback(fallback);
            Assert.Equal(targetProperty, result);
        }
    }
}
