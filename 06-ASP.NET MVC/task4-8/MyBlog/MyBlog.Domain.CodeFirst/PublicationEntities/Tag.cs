using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Domain.CodeFirst.PublicationEntities
{
    public partial class Tag
    {
        public int Id { get; set; }
        public string TagName { get; set; }
        public ICollection<TagToArticle> TagToArticle { get; set; }
    }
}
