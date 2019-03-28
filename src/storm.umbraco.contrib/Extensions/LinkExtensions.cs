using System.Web;

namespace storm.umbraco.contrib.Extensions
{
    public static class LinkExtensions
    {
        public static IHtmlString LinkTarget(this string value)
        {
            return (!string.IsNullOrEmpty(value) && value == "_blank") ? new HtmlString(@" target=""_blank"" rel=""noopener""") : new HtmlString(string.Empty);
        }
    }
}
