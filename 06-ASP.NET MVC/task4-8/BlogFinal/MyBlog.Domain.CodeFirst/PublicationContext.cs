using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyBlog.Domain.CodeFirst.PublicationEntities;

namespace MyBlog.Domain.CodeFirst
{
    public class PublicationContext : DbContext
    {
        public PublicationContext()
            : base("PublicationContext")

        {
            Database.SetInitializer<PublicationContext>(null);
        }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<TagToArticle> TagToArticles { get; set; }
    }
}
