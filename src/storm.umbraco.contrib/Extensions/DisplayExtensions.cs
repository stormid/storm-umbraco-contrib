using System.Web;

namespace storm.umbraco.contrib.Extensions
{
    public static class DisplayExtensions
    {
        public static IHtmlString AddBrs(this string value)
        {
            return !string.IsNullOrEmpty(value) ? new HtmlString(value.Replace("\n", "<br />")) : new HtmlString(string.Empty);
        }

        /// <param name="value">The string to be trimmed.</param>
        /// <param name="length">The character length the string will be shortened to.</param>
        /// <param name="keepFullWordAtEnd">Keep the last full word, even if it goes over the maximum length.</param>
        /// <param name="ellipsis">An optional additional string which will be appended at the end of the truncated string.</param>
        /// <returns>The original string shortened to a specific character length.</returns>
        public static string Truncate(this string value, int length, bool keepFullWordAtEnd = true, string ellipsis = "...")
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            if (value.Length < length) return value;

            value = value.Substring(0, length);

            if (keepFullWordAtEnd)
            {
                value = value.Substring(0, value.LastIndexOf(' '));
            }

            if (!string.IsNullOrWhiteSpace(ellipsis))
            {
                value += ellipsis;
            }

            return value;
        }
    }
}
