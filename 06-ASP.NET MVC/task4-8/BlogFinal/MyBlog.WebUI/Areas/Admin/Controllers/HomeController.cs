using MyBlog.WebUI.Areas.Admin.Filters;
using MyBlog.WebUI.Areas.Admin.Models;
using MyBlog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyBlog.WebUI.Areas.Admin.Controllers
{
    [ForAdmin]
    public class HomeController : Controller
    {
        MyBlogRepository repository = MyBlogRepository.Instance;
        int pageSize = 20;
        int pageRange = 5;
        public ActionResult Index(int page = 1)
        {
            ViewBag.pageInfo = new PageInfo()
            {
                CurPage = page,
                ItemsPerPage = pageSize,
                TotalItems = repository.Articles.Count,
                PageRange = pageRange
            };
            return View(repository.Articles.Skip((page - 1) * pageSize).Take(pageSize).ToList());
        }
        public ActionResult AddPublication()
        {
            NewPublicationViewModel newPublication = new NewPublicationViewModel(repository);
            return View(newPublication);
        }

        //for pass through html tags
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AddPublication(NewPublicationViewModel newPublication)
        {
            newPublication.FillTags(repository);
            if (ModelState.IsValid)
            {
                repository.AddPublication(newPublication);
                return RedirectToAction("EditSuccesfull");
            }
            else
            {
                return View(newPublication);
            }
        }
        public ActionResult Details(int id)
        {
            return View(repository.Articles.Find(x => x.Id == id));
        }
        public ActionResult Edit(int id)
        {
            NewPublicationViewModel result = new NewPublicationViewModel(repository, id);
            return View("AddPublication", result);
        }
        public ActionResult Delete(int id)
        {
            repository.DeleteRestorePublication(id);
            return RedirectToAction("Index");
        }
        public ActionResult Restore(int id)
        {
            repository.DeleteRestorePublication(id);
            return RedirectToAction("Index");
        }
        public ActionResult RecycleBin()
        {
            return View(repository.Articles.Where(x => x.Deleted == true).Select(x => x).ToList());
        }
        public ActionResult Drop(int id)
        {
            return View(repository.Articles.Find(x => x.Id == id));
        }
        [HttpPost]
        public ActionResult DropPublication(int id)
        {
            repository.DropPublication(id);
            return RedirectToAction("RecycleBin");
        }
    }
}
