using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyBlog.WebUI.Models;
using MyBlog.WebUI.Models.DbFirst;

namespace MyBlog.WebUI.Controllers
{
    //[Authorize]
    public class FeedbackController : Controller
    {
        //
        // GET: /Feedback/
        MyBlogRepository repository = MyBlogRepository.Instance;
        FeedbacksShowViewModel result;
        public FeedbackController()
        {
            result = new FeedbacksShowViewModel(repository);
        }
        public ActionResult Index()
        {
            return View(result);
        }
        public ActionResult Edit(int id)
        {
            result.EditId = id;
            return View("Index", result);
        }
        [HttpPost]
        public ActionResult Edit(Feedbacks newFeedback)
        {
            repository.EditFeedback(newFeedback);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public ActionResult Add(Feedbacks newFeedback)
        {
            if (ModelState.IsValid)
            {
                repository.AddFeedback(newFeedback);
                return RedirectToAction("Index");
            }
            else
            {
                return View("Index", result);
            }
        }
        public ActionResult Delete(int id)
        {
            repository.DeleteFeedback(id);
            return RedirectToAction("Index");
        }

    }
}
