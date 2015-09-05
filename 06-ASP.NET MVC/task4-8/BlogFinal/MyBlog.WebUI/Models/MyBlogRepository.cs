using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        private UsersContext db;
        private PublicationContext publications;
        public List<Feedbacks> Feedbacks
        {
            get
            {
                return db.Feedbacks.ToList();
            }
        }
        
        public List<Users> AllUsers
        {
            get
            {
                return db.Users.ToList();
            }
        }
        public List<AboutSelf> AboutSelf
        {
            get
            {
                return db.AboutSelf.ToList();
            }
        }
        public void AddFeedback(Feedbacks feedback)
        {  
            feedback.DateTime = DateTime.Today.ToShortDateString() + " в " + DateTime.Now.ToLongTimeString();
            db.Feedbacks.Add(feedback);
            db.SaveChanges();
            
        }
        public void EditFeedback(Feedbacks updatedFeedback)
        {
            updatedFeedback.DateTime = DateTime.Today.ToShortDateString() + " в " + DateTime.Now.ToLongTimeString();
            db = new UsersContext();// without this updating dosen't work
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
            db = new UsersContext();
            publications = new PublicationContext();
        }
        public bool AboutExist(int userId)
        {
            int id = db.AboutSelf.Where(item => item.UserId == userId).Select(item => item.UserId).FirstOrDefault();
            return id != 0;
        }
        public void AddAbout(AboutSelf about)
        {

            if (!AboutExist(about.UserId))  //dosen't exist
            {
                db.AboutSelf.Add(about);
                db.SaveChanges();
            }
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
        public List<Int32> GetArticlesToTags(Int32 tagId)
        {
            return publications.TagToArticles.Where(x => x.TagId == tagId).Select(x => x.ArticleId).ToList<Int32>();
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
        public void DeleteUser(int id)
        {
            db.Users.Remove(db.Users.Find(id));
            db.SaveChanges();
        }
        public void LockUnlock(int id)
        {
            Users newUser = AllUsers.Find(x => x.UserId == id);
            newUser.Active = !newUser.Active;
            db.Entry(newUser).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void AddVote(int id, int rate)
        {
            Votes newVote = new Votes();
            newVote.UserId = id;
            newVote.Rate = rate;
            db.Votes.Add(newVote);
            db.SaveChanges();
        }
        public bool UserVoted(string name)
        {
            int id = GetUserId(name);
            if (db.Votes.Where(x => x.UserId == id).Select(x => x).FirstOrDefault() == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        public int GetUserId(string name)
        {
            return AllUsers.Where(x => x.UserName == name).Select(x => x.UserId).FirstOrDefault();
        }
        public double GetBlogRate()
        {
            double totalVotes = 0.0;
            foreach(var item in db.Votes)
            {
                totalVotes += item.Rate;
            }
            return totalVotes / db.Votes.Count();
        }
        public void EditUser(Users user)
        {
            db = new UsersContext();
            db.Entry(user).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}