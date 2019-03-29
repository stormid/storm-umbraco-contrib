using System.Web;

namespace storm.umbraco.contrib.Extensions
{
    public static class DisplayExtensions
    {
        public static IHtmlString AddBrs(this string value)
        {
            return !string.IsNullOrEmpty(value) ? new HtmlString(value.Replace("\n", "<br />")) : new HtmlString(string.Empty);
        }

        public static string Truncate(this string value, int length, string ellipsis, bool keepFullWordAtEnd)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            if (value.Length < length) return value;

            value = value.Substring(0, length);

            if (keepFullWordAtEnd)
            {
                value = value.Substring(0, value.LastIndexOf(' '));
            }

            return value + ellipsis;
        }
    }
}
