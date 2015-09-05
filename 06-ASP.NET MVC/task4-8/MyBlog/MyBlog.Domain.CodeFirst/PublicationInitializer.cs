using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using MyBlog.Domain.CodeFirst.PublicationEntities;


namespace MyBlog.Domain.CodeFirst
{
    public class PublicationInitializer : DropCreateDatabaseIfModelChanges<PublicationContext>
    {
        protected override void Seed(PublicationContext context)
        {
            //base.Seed(context);
            List<Article> articles = new List<Article> 
            {
                new Article
                {                    
                    ArticleText = "Article1",
                    ArticleTitle = "title1" 
                },
                new Article
                {
                    ArticleText = "Article2",
                    ArticleTitle = "title2" 
                }
            };
            articles.ForEach(s => context.Articles.Add(s));
            context.SaveChanges();
            List<Tag> Tags = new List<Tag>
            {
                new Tag
                {
                    TagName = "Tag1"
                },
                new Tag
                {
                    TagName = "Tag2"
                },
                new Tag
                {
                    TagName = "Tag3"
                }

            };
            Tags.ForEach(s => context.Tags.Add(s));
            context.SaveChanges();
            context.TagToArticles.Add(new TagToArticle { ArticleId = 1, TagId = 1 });
            context.TagToArticles.Add(new TagToArticle { ArticleId = 1, TagId = 2 });
            context.TagToArticles.Add(new TagToArticle { ArticleId = 2, TagId = 2 });
            context.TagToArticles.Add(new TagToArticle { ArticleId = 2, TagId = 3 });
            context.SaveChanges();
        }
    }
}
