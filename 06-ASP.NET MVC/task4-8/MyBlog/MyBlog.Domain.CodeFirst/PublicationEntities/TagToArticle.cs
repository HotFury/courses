using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.CodeFirst.PublicationEntities
{
    public class TagToArticle
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        public int TagId { get; set; }
        public virtual Article Article { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
