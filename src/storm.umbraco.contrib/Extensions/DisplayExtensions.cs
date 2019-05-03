using System.Web;

namespace storm.umbraco.contrib.Extensions
{
    public static class DisplayExtensions
    {
        public static IHtmlString AddBrs(this string value)
        {
            return !string.IsNullOrEmpty(value) ? new HtmlString(value.Replace("\n", "<br />")) : new HtmlString(string.Empty);
        }

        /// <summary>
        /// Cuts off a string after a specified character length.
        /// </summary>
        /// <param name="value">The string to be shortened.</param>
        /// <param name="length">The maximum character length, characters after this will be trimmed.</param>
        /// <param name="keepFullWordAtEnd">Do not split in the middle of a word which goes beyond the character length.</param>
        /// <param name="ellipsis">A string to be appended at the end of the truncated value.</param>
        /// <returns></returns>
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
