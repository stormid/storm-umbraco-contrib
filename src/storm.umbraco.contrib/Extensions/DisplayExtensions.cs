using System.Web;

namespace storm.umbraco.contrib.Extensions
{
    public static class DisplayExtensions
    {
        public static IHtmlString AddBrs(this string value)
        {
            return !string.IsNullOrEmpty(value) ? new HtmlString(value.Replace("\n", "<br />")) : new HtmlString(string.Empty);
        }
    }
}
