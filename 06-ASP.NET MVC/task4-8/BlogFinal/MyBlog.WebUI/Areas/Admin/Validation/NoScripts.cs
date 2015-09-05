using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.WebUI.Areas.Admin.Validation
{
    public class NoScripts : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return !value.ToString().Contains("<script");
        }
    }
}