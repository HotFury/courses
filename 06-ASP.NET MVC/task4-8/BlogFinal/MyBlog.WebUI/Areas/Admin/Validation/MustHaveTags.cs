using MyBlog.WebUI.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyBlog.WebUI.Areas.Admin.Validation
{
    public class MustHaveTags : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            NewPublicationViewModel newPublic =  value as NewPublicationViewModel;
            if (newPublic.SelectedTags == null && newPublic.NewTags == null)
            {
                return false;
            }
            return true;
        }
    }
}