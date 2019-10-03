using storm.umbraco.contrib.Extensions;
using System.Web;
using Xunit;

namespace contrib.tests.Extensions
{
    public class IsNullOrEmptyHtmlTests
    {
        [Fact]
        public void Htmlstring_NullOrEmptyHtml_Null()
        {
            IHtmlString value = null;

            Assert.True(value.IsNullOrEmptyHtml());
        }

        [Fact]
        public void Htmlstring_NullOrEmptyHtml_EmptyHtml()
        {
            IHtmlString value = new HtmlString("<p> </p>");

            Assert.True(value.IsNullOrEmptyHtml());
        }

        [Fact]
        public void Htmlstring_NullOrEmptyHtml_HtmlWithContent()
        {
            IHtmlString value = new HtmlString("<p>Lorem ipsum dolor sit amet.</p>");
            Assert.False(value.IsNullOrEmptyHtml());
        }
    }
}
