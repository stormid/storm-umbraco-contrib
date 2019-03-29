using Umbraco.Core.Models;
using Umbraco.Web;

namespace storm.umbraco.contrib.Extensions
{
    public static class PublishedContentExtensions
    {
        public static string H1PageTitle(this IPublishedContent content)
        {
            var h1PageTitle = content.GetPropertyValue<string>(nameof(H1PageTitle));

            return string.IsNullOrEmpty(h1PageTitle) ? content.Name : h1PageTitle;
        }
    }
}
