using MyBlog.Domain.CodeFirst.PublicationEntities;
using MyBlog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyBlog.WebUI.Areas.Admin.Models
{
    public partial class NewPublicationViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ArticleText { get; set; }
        public string NewTags { get; set; }
        public List<SelectListItem> Tags { get; set; }
        public List<int> SelectedTags { get; set; }
        public void FillTags(MyBlogRepository repository)
        {
            this.Tags = repository.Tags.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.TagName
            }).ToList();
        }
        public NewPublicationViewModel(MyBlogRepository repository)
        {
            FillTags(repository);
        }
        public NewPublicationViewModel(MyBlogRepository repository, int id)
        {
            this.Id = id;
            var publication =  repository.Articles.Find(x => x.Id == id);
            this.Title = publication.ArticleTitle;
            this.ArticleText = publication.ArticleText;
            var selectedTagsId = repository.GetTagsIdToArticle(id);
            this.Tags = repository.Tags.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.TagName
            }).ToList();
            foreach(int curSelTagId in selectedTagsId)
            {
                for (int i = 0; i < this.Tags.Count; i++ )
                {
                    if (curSelTagId.ToString() == this.Tags[i].Value)
                    {
                        this.Tags[i].Selected = true;
                    }
                }
            }
            
            
            
            
            
        }
        public NewPublicationViewModel()
        {

        }
    }
}