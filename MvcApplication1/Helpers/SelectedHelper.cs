using System;
using System.Web.Mvc;

namespace MvcApplication1.Helpers
{
    public static class SelectedHelper
    {

        public static string Selected<T>(this HtmlHelper helper, T value1, T value2)
        {
            if (value1.Equals(value2))
                return "class=\"selected\"";
            return String.Empty;
        }

    }
}
