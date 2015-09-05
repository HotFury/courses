using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Domain.CodeFirst.PublicationEntities;

namespace MyBlog.WebUI.Models.CodeFirst
{
    public class PublicationModelView
    {
        public Article Article { get; set; }
        public List<string> TagNames { get; set; }
        public PublicationModelView(List<string> tagNames)
        {
            this.TagNames = tagNames;
        }
        
    }
}