using MyBlog.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace MyBlog.WebUI.Models.DbFirst
{
    public class FeedbacksShowViewModel
    {
        public IEnumerable<Feedbacks> Feedbacks { get; set; }
        public Feedbacks NewFeedback { get; set; }
        public int EditId {get; set;}
        public FeedbacksShowViewModel(MyBlogRepository repository)
        {
            EditId = -1;
            Feedbacks = repository.Feedbacks;
            NewFeedback = new Feedbacks();
        }
    }
}