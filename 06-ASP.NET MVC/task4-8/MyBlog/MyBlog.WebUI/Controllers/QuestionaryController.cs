using MyBlog.Domain.Entities;
using MyBlog.WebUI.Models;
using MyBlog.WebUI.Models.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyBlog.WebUI.Controllers
{
    public class QuestionaryController : Controller
    {
        //
        // GET: /Questionary/
        MyBlogRepository repository = MyBlogRepository.Instance;
        AboutSelfFormViewModel result;
        BuildRadioOrCheck checkRadioBuilder = new BuildRadioOrCheck();
        public QuestionaryController()
        {
            result = new AboutSelfFormViewModel(repository);
        }
        
        private IEnumerable<SelectListItem> GetUsers()
        {
            IEnumerable<SelectListItem> Users =
            repository.Users.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Nick
            });
            return Users;
        }
        private void PrepareView()
        {
            result.GenderRadio = checkRadioBuilder.Build(result.GenderText, "gender", false);
            result.HobbiesChek = checkRadioBuilder.Build(result.HobbyText, "hobbies", true);
            ViewBag.List = GetUsers();
        }
        public ActionResult Index()
        {
            PrepareView();
            return View(result);
        }             [HttpPost]        public ActionResult AddAbout(AboutSelf AboutSelf, FormCollection form)
        {
            AboutSelf.Sex = form["gender"];
            AboutSelf.Hobbies = form["hobbies"];
            if (ModelState.IsValid)
            {
                ViewBag.Message = repository.AddAbout(AboutSelf);
                return View();
            }
            else
            {
                PrepareView();
                return View("Index", result);
            }
        }
    }
}
