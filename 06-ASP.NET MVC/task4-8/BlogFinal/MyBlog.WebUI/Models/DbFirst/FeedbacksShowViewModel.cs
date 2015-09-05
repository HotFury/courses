using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;



namespace MyBlog.WebUI.Models.DbFirst
{
    public class FeedbacksShowViewModel
    {
        public IEnumerable<Feedbacks> Feedbacks { get; set; }
        public IEnumerable<Users> Users { get; set; }
        public Feedbacks NewFeedback { get; set; }
        public int EditId {get; set;}
        public FeedbacksShowViewModel(MyBlogRepository repository)
        {
            EditId = -1;
            Feedbacks = repository.Feedbacks;
            NewFeedback = new Feedbacks();
            Users = repository.AllUsers;
        }
        public string GetUserNameById(int id)
        {
            string result = Users.Where(x => x.UserId == id).Select(x => x.UserName).First();
            return result;
        }
        public int GetUserIdByName(string name)
        {
            return Users.Where(x => x.UserName == name).Select(x => x.UserId).First();
        }
    }
}