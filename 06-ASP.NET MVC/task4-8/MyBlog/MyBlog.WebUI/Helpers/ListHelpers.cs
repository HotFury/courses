using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.WebUI.Helpers
{
    public static class ListHelpers
    {
        public static MvcHtmlString CreateList(this HtmlHelper html, List<String> items, String CSSClass, bool ordered)
        {
            TagBuilder list;
            if (ordered)
            {
                list = new TagBuilder("ol");
            }
            else
            {
                list = new TagBuilder("ul");
            }
            list.AddCssClass(CSSClass);
            foreach(String item in items)
            {
                TagBuilder li = new TagBuilder("li");
                li.InnerHtml += item;
                list.InnerHtml += li.ToString();
            }
            return new MvcHtmlString(list.ToString());
        }
    }
}