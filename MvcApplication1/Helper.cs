using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Linq.Expressions;

namespace MvcApplication1
{
    public static class Helper
    {
        public static string IsActiveTab(this HtmlHelper helper, string action)
        {
            string result = string.Empty;

            string currentAction = helper.ViewContext.RouteData.Values["controller"].ToString();
            if (string.Equals(action, currentAction, StringComparison.InvariantCultureIgnoreCase))
            {
                result = "ui-state-active ui-tabs-selected";
            }

            return result;
        }

        public static string GetGravatarUrl(this HtmlHelper helper, int imageSize)
        {
            string result = string.Empty;

            MembershipUser User = Membership.GetUser();
            if (User != null)
            {
                System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] bs = System.Text.Encoding.UTF8.GetBytes(User.Email);
                bs = x.ComputeHash(bs);
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                foreach (byte b in bs)
                {
                    s.Append(b.ToString("x2").ToLower());
                }
                string gravatarHash = s.ToString();

                result = string.Format("http://www.gravatar.com/avatar/{1}.png?s={0}", imageSize, gravatarHash);

            }

            return result;
        }

        public static string GetGravatarUrlEmail(this HtmlHelper helper, int imageSize,String email)
        {
            string result = string.Empty;

            
                System.Security.Cryptography.MD5CryptoServiceProvider x = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] bs = System.Text.Encoding.UTF8.GetBytes(email);
                bs = x.ComputeHash(bs);
                System.Text.StringBuilder s = new System.Text.StringBuilder();
                foreach (byte b in bs)
                {
                    s.Append(b.ToString("x2").ToLower());
                }
                string gravatarHash = s.ToString();

                result = string.Format("http://www.gravatar.com/avatar/{1}.png?s={0}", imageSize, gravatarHash);

            

            return result;
        }

        public static MvcHtmlString ValidationFor<Model>(this HtmlHelper<Model> helper, Expression<Func<Model, string>> expression)
        {
            MvcHtmlString message = System.Web.Mvc.Html.ValidationExtensions.ValidationMessageFor<Model, string>(helper, expression);
            TagBuilder div = new TagBuilder("div");
            if(message == null)
            {

            }
            else
            {
                div.AddCssClass("editor-field-error ui-state-error");
                div.InnerHtml = message.ToHtmlString();
            }

            return MvcHtmlString.Create(div.ToString());
        }

        public static MvcHtmlString GetTheme(this HtmlHelper helper)
        {
            string baseTheme = "redmond";
            string theme = baseTheme;
            if (helper.ViewContext.HttpContext.User.Identity.IsAuthenticated)
            {
                theme = helper.ViewContext.HttpContext.Profile.GetPropertyValue("Theme").ToString();
                if (string.IsNullOrEmpty(theme))
                {
                    helper.ViewContext.HttpContext.Profile.SetPropertyValue("Theme", baseTheme);
                    theme = baseTheme;
                }
            }
            return MvcHtmlString.Create(theme);
        }
    }
}