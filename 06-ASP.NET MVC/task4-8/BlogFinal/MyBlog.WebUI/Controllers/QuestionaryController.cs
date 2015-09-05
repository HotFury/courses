using MyBlog.WebUI.Models;
using MyBlog.WebUI.Models.DbFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace MyBlog.WebUI.Controllers
{
    [Authorize]
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
        private void PrepareView()
        {
            result.GenderRadio = checkRadioBuilder.Build(result.GenderText, "gender", false);
            result.HobbiesChek = checkRadioBuilder.Build(result.HobbyText, "hobbies", true);
            result.UserId = repository.AllUsers.Where(x => x.UserName == User.Identity.Name).Select(x => x.UserId).First();
        }
        public ActionResult Index()
        {
            PrepareView();
            if (!repository.AboutExist(result.UserId))
            {
                return View(result);
            }
            else
            {
                return RedirectToAction("AboutExist");
            }
        }
        public ActionResult AboutExist()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbout(AboutSelf AboutSelf, FormCollection form)
        {
            AboutSelf.Sex = form["gender"];
            AboutSelf.Hobbies = form["hobbies"];
            AboutSelf.UserId = Convert.ToInt32(form["UserId"]);
            if (ModelState.IsValid)
            {
                repository.AddAbout(AboutSelf);
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
