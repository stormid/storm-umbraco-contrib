using Umbraco.Core.Models;
using Umbraco.Web;

namespace storm.umbraco.contrib.Extensions
{
    public static class ImageExtensions
    {
        public static string GetSafeCropUrl(this IPublishedContent content, string cropAlias, string defaultImage = "")
        {
            return content == null ? defaultImage : content.GetCropUrl(cropAlias: cropAlias);
        }
    }
}
