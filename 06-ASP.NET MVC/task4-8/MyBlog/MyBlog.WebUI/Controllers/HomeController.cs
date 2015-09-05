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

namespace MyBlog.WebUI.Controllers
{
    public class HomeController : Controller
    {
        MyBlogRepository repository = MyBlogRepository.Instance;
        
        public ActionResult Index(int page = 1)
        {
            PublicationPreviewViewModel result = new PublicationPreviewViewModel(repository.Articles, page);
            return View(result);
        }
        public ActionResult ReadMore(int Id)
        {
            PublicationModelView result = new PublicationModelView(repository.GetTagNamesToArticle(Id));
            result.Article = repository.GetArticle(Id);
            return View("Publication", result);
        }
        

    }
}
