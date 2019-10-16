using System.Web.Mvc;

namespace Storm.Umbraco.Contrib.Extensions
{
    public static class HtmlExtensions
    {
        public static string If(this HtmlHelper helper, bool condition, string ifTrue, string ifFalse = "") => condition ? ifTrue : ifFalse;
    }
}
