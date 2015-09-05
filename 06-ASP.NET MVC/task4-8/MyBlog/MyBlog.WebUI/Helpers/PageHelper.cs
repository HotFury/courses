using MyBlog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.WebUI.Helpers
{
    public static class PageHelper
    {
        public static MvcHtmlString CreatePageLinks(this HtmlHelper html, PageInfo pageInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for (int i = pageInfo.StartPage; i <= pageInfo.PageLimit; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.InnerHtml = i.ToString();
                if (i == pageInfo.CurPage)
                {
                    tag.AddCssClass("selected-page");
                }
                else
                {
                    tag.MergeAttribute("href", pageUrl(i));
                    tag.AddCssClass("page-link");
                }
                
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}