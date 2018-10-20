using System.Web.Mvc;

namespace AspNetMvcEcommerce.CustomHtmlHelpers
{
    public static class Helpers
    {
        public static MvcHtmlString Strong(this HtmlHelper html, string expression)
        {
            return new MvcHtmlString("<strong>" + expression + "</strong>");
        }
    }
}