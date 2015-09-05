using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.CodeFirst.PublicationEntities
{
    public partial class Article
    {
        public int Id { get; set; }
        
        public string ArticleText { get; set; }
        [Display(Name = "Название статьи")]
        public string ArticleTitle { get; set; }
        public bool Deleted { get; set; }
        public ICollection<TagToArticle> TagToAtricle { get; set; }
        
    }
}
