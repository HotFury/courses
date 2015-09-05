using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace MyBlog.WebUI.Areas.Admin.Validation
{
    public class ArticleNotEmpty : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value != null)
            {
                string cleanArticle = Regex.Replace(value.ToString(), @"<[\/]*[p|span|strong|em|strike|ul|ol|li|blockquote|a href=].*?>|[\s]|(&nbsp;)*", string.Empty);
                if (cleanArticle != String.Empty)
                {
                    return true;
                }
            }
            return false;
        }
    }
}