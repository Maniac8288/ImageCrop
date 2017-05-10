using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ImageCrop.Extensions
{
    public static class MvcHtmlStringExtensions
    {
        public static IHtmlString Html(this MvcHtmlString html)
        {
            return new HtmlString(html.ToHtmlString().Replace("\n", "").Replace("\r", "").Replace("'", "\\'"));
        }

    }
}