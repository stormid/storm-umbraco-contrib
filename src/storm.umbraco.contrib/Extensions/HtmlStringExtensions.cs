using HtmlAgilityPack;
using System.Web;

namespace storm.umbraco.contrib.Extensions
{
    public static class HtmlStringExtensions
    {
        /// <summary>
        /// Indicates whether the specified <see cref="HtmlString">HtmlString</see> is null or contains only html tags with no inner text.         
        /// </summary>
        /// <param name="value">The HtmlString to test.</param>
        /// <returns></returns>
        public static bool IsNullOrEmptyHtml(this IHtmlString value)
        {
            if (value == null)
            {
                return true;
            }

            var document = new HtmlDocument();
            document.LoadHtml(value.ToHtmlString());
            string textValue = HtmlEntity.DeEntitize(document.DocumentNode.InnerText);

            return string.IsNullOrWhiteSpace(textValue);
        }
    }
}
