using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyBlog.Domain.Entities;
using System.Web.WebPages.Html;
namespace MyBlog.WebUI.Models.DbFirst
{
    public class AboutSelfFormViewModel
    {
        private List<String> genderText;
        private List<String> hobbyText;
        public List<String> GenderText
        {
            get { return genderText; }
        }
        public List<String> HobbyText
        {
            get { return hobbyText;}
        }
        private IEnumerable<Users> users;
        public IEnumerable<Users> Users 
        {
            get{ return users;}
        }
        public AboutSelf AboutSelf { get; set; }
        public AboutSelfFormViewModel(MyBlogRepository repository)
        {
            users = repository.Users;
            AboutSelf = new AboutSelf();
            genderText = new List<String> { "мужской", "женский" };
            hobbyText = new List<String> { "спорт", "видеоигры", "коллекционирование", "йога" };
        }
        public List<String> GenderRadio { get; set; }
        public List<String> HobbiesChek { get; set; }
    }
}