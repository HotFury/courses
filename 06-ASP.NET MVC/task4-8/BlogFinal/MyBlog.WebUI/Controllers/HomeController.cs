using MyBlog.Domain;
using MyBlog.Domain.CodeFirst;
using MyBlog.WebUI.Models;
using MyBlog.WebUI.Models.CodeFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.Domain.CodeFirst.PublicationEntities;
using MyBlog.WebUI.Filters;

namespace MyBlog.WebUI.Controllers
{
    
    public class HomeController : Controller
    {
        MyBlogRepository repository = MyBlogRepository.Instance;
        [InitializeSimpleMembership]
        public ActionResult Index(int page = 1)
        {
            ViewBag.Voted = repository.UserVoted(User.Identity.Name);
            ViewBag.BlogRate = String.Format("{0:0.00}",repository.GetBlogRate());
            PublicationPreviewViewModel result = new PublicationPreviewViewModel(repository.Articles, page);
            return View(result);
        }
        public ActionResult ReadMore(int Id)
        {
            PublicationModelView result = new PublicationModelView(repository.GetTagNamesToArticle(Id));
            result.Article = repository.GetArticle(Id);
            return View("Publication", result);
        }
        [Authorize]
        public ActionResult TakeVote(string userName, FormCollection form)
        {
            int id = repository.GetUserId(userName);
            if (id != 0)
            {
                repository.AddVote(id, Convert.ToInt32(form["vote"]));
            }
            return RedirectToAction("Index");
        }
        public ActionResult SearchByTag(string id)
        {
            ViewBag.curTag = id;
            PublicationPreviewViewModel result = new PublicationPreviewViewModel(repository.Articles, repository, id);
            return View(result);
        }
    }
}
