using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace MvcApplication1.Helpers
{
    public static class ImageActionLinkHelper
    {

        public static string ImageActionLink(this AjaxHelper helper, string imageUrl, string altText, string actionName, object routeValues, AjaxOptions ajaxOptions)
        {
            var builder = new TagBuilder("img");
            builder.MergeAttribute("src", imageUrl);
            builder.MergeAttribute("alt", altText);
            var link = helper.ActionLink("[replaceme]", actionName, routeValues, ajaxOptions);
            return link.ToString().Replace("[replaceme]", builder.ToString(TagRenderMode.SelfClosing));
        }

    }
}
