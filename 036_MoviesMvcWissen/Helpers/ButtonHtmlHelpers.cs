using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _036_MoviesMvcWissen.Helpers
{
    public static class ButtonHtmlHelpers
    {
        public static MvcHtmlString SaveButton(this HtmlHelper htmlHelper)
        {
            TagBuilder tagBuilder = new TagBuilder("Button");
            tagBuilder.InnerHtml = "Save";
            tagBuilder.MergeAttribute("type", "submit");
            tagBuilder.MergeAttribute("class", "btn btn-success");
            return MvcHtmlString.Create(tagBuilder.ToString());

        }
    }
}