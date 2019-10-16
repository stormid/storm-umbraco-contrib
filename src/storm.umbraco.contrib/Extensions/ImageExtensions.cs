using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Storm.Umbraco.Contrib.Extensions
{
    public static class ImageExtensions
    {
        public static string GetSafeCropUrl(this IPublishedContent content, string cropAlias, string defaultImage = "")
        {
            return content == null ? defaultImage : content.GetCropUrl(cropAlias: cropAlias);
        }
    }
}
