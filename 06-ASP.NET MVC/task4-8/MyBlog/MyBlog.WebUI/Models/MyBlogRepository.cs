using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Domain.Entities;
using System.Data.Entity;
using System.Web.Mvc;
using MyBlog.Domain.CodeFirst;
using MyBlog.Domain.CodeFirst.PublicationEntities;
using MyBlog.WebUI.Areas.Admin.Models;


namespace MyBlog.WebUI.Models
{
    public class MyBlogRepository
    {
        private char splitSymbol = ' ';
        private static MyBlogRepository instance;
        public static MyBlogRepository Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MyBlogRepository();
                }
                return instance;
            }
        }
        private MyBlogEntities db;
        private PublicationContext publications;
        public List<Feedbacks> Feedbacks
        {
            get
            {
                return db.Feedbacks.ToList();
            }
        }
        
        public List<Users> Users
        {
            get
            {
                return db.Users.ToList();
            }
        }
        public void AddFeedback(Feedbacks feedback)
        {
            feedback.DateTime = DateTime.Today.ToShortDateString() + " в " + DateTime.Now.ToLongTimeString();
            int id = db.Users.Where(item => item.Nick == feedback.Users.Nick).Select(item=>item.Id).FirstOrDefault();
            if (id != 0)
            {
                feedback.Users = null;
                feedback.UserId = id;
            }
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
        }
        public void EditFeedback(Feedbacks updatedFeedback)
        {

            updatedFeedback.DateTime = DateTime.Today.ToShortDateString() + " в " + DateTime.Now.ToLongTimeString();
            db = new MyBlogEntities();// without this updating dosen't work
            db.Entry(updatedFeedback).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteFeedback(int id)
        {
            Feedbacks feedback = db.Feedbacks.Find(id);
            db.Feedbacks.Remove(feedback);
            db.SaveChanges();
        }
        public MyBlogRepository()
        {
            db = new MyBlogEntities();
            publications = new PublicationContext();
        } 
        public string AddAbout(AboutSelf about)
        {
            int id = db.AboutSelf.Where(item => item.UserId == about.UserId).Select(item => item.UserId).FirstOrDefault();
            if (id == 0)  //dosen't exist
            {
                db.AboutSelf.Add(about);
                db.SaveChanges();
                return "Добавление успешно";
            }
            return "Иформация о пользователе уже существует";
        }
        public List<Article> Articles
        {
            get
            {
                return publications.Articles.ToList();
            }
        }
        public List<Tag> Tags
        {
            get
            {
                return publications.Tags.ToList();
            }
        }
        private void AddTag(Tag tag)
        {
            publications.Tags.Add(tag);
            publications.SaveChanges();
        }
        private int GetTagId(string tagName)
        {
            var temp = publications.Tags.Where(x => x.TagName == tagName).FirstOrDefault();
            int tagId;
            if (temp == null)
            {
                Tag tag = new Tag { TagName = tagName };
                AddTag(tag);
                tagId = publications.Tags.OrderByDescending(x => x.Id).First<Tag>().Id;
            }
            else
            {
                tagId = temp.Id;
            }
            return tagId;
        }
        private void AddArticle(Article article)
        {
            publications.Articles.Add(article);
            publications.SaveChanges();
        }
        public void AddPublication(NewPublicationViewModel newPublication)
        {
            int articleId = newPublication.Id;
            Article newArticle = new Article {ArticleTitle = newPublication.Title, ArticleText = newPublication.ArticleText };
            if (articleId == 0)
            {
                AddArticle(newArticle);
                articleId = publications.Articles.OrderByDescending(x => x.Id).First<Article>().Id;
            }
            else
            {
                newArticle.Id = articleId;
                publications = new PublicationContext();
                publications.Entry(newArticle).State = EntityState.Modified;
                List<TagToArticle> curConnections = publications.TagToArticles.Where(x => x.ArticleId == articleId).Select(x => x).ToList();
                foreach (TagToArticle curEntity in curConnections)
                {
                    publications.TagToArticles.Remove(curEntity);
                }
            }
            List<string> allTags = new List<string>();
            if (newPublication.NewTags != null)
            {
                allTags = newPublication.NewTags.Split(splitSymbol).ToList<string>();
            }
            if (newPublication.SelectedTags != null)
            {
                foreach (int tagId in newPublication.SelectedTags)
                {
                    allTags.Add(Tags.Where(x => x.Id == tagId).Select(x => x.TagName).FirstOrDefault());
                }
            }
            foreach (string curTagName in allTags)
            {
                int tagId = GetTagId(curTagName);
                publications.TagToArticles.Add(new TagToArticle { ArticleId = articleId, TagId = tagId });
            }
            
            publications.SaveChanges();
        }
        public List<Int32> GetTagsIdToArticle(Int32 articleId)
        {
            return publications.TagToArticles.Where(x => x.ArticleId == articleId).Select(x => x.TagId).ToList<Int32>();
        }
        public List<string> GetTagNamesToArticle(Int32 articleId)
        {
            List<Int32> tagsId = GetTagsIdToArticle(articleId);
            List<string> tagNames = new List<string>();
            foreach (int id in tagsId)
            {
                tagNames.Add(publications.Tags.Find(id).TagName);
            }
            return tagNames;
        }
        public Article GetArticle(int id)
        {
            return publications.Articles.Find(id);
        }
        public void DeleteRestorePublication(int id)
        {
            Article delArticle = new Article();
            delArticle = publications.Articles.Find(id);
            delArticle.Deleted = !delArticle.Deleted;
            publications.Entry(delArticle).State = EntityState.Modified;
            publications.SaveChanges();
        }
        public void DropPublication(int id)
        {
            Article delArticle = new Article();
            delArticle = publications.Articles.Find(id);
            publications.Articles.Remove(delArticle);
            publications.SaveChanges();
        }
        
    }
}