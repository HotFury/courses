using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages.Html;
using MyBlog.WebUI.Models;
using System.Security.Principal;
namespace MyBlog.WebUI.Models.DbFirst
{
    public class AboutSelfFormViewModel
    {
        private List<String> genderText;
        private List<String> hobbyText;
        public int UserId { get; set; }
        public List<String> GenderText
        {
            get { return genderText; }
        }
        public List<String> HobbyText
        {
            get { return hobbyText;}
        }
        public AboutSelf AboutSelf { get; set; }
        public AboutSelfFormViewModel(MyBlogRepository repository)
        {
            AboutSelf = new AboutSelf();
            genderText = new List<String> { "мужской", "женский" };
            hobbyText = new List<String> { "спорт", "видеоигры", "коллекционирование", "йога" };
        }
        public List<String> GenderRadio { get; set; }
        public List<String> HobbiesChek { get; set; }
    }
}