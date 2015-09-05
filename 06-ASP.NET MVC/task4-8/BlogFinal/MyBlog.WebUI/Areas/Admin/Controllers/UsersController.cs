using MyBlog.WebUI.Areas.Admin.Filters;
using MyBlog.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

namespace MyBlog.WebUI.Areas.Admin.Controllers
{
    [ForAdmin]
    public class UsersController : Controller
    {
        //
        // GET: /Admin/Users/
        MyBlogRepository repository = MyBlogRepository.Instance;
        int pageSize = 20;
        int pageRange = 5;
        public ActionResult UsersManage(int page = 1)
        {
            ViewBag.pageInfo = new PageInfo()
            {
                CurPage = page,
                ItemsPerPage = pageSize,
                TotalItems = repository.AllUsers.Count,
                PageRange = pageRange
            };
            return View(repository.AllUsers.Skip((page - 1) * pageSize).Take(pageSize).ToList());
        }
        public ActionResult DeleteUser(int id)
        {
            return View(repository.AllUsers.Find(x => x.UserId == id));
        }
        public ActionResult DropUser(int UserId)
        {
            repository.DeleteUser(UserId);
            return RedirectToAction("UsersManage");
        }
        public ActionResult LockUnlock(int id)
        {
            repository.LockUnlock(id);
            return RedirectToAction("UsersManage");
        }
        public ActionResult EditUser(int id)
        {
            return View(repository.AllUsers.Find(x => x.UserId == id));
        }
        [HttpPost]
        public ActionResult EditUser(Users user)
        {
            repository.EditUser(user);
            return View("EditSuccesfull");
        }
        public ActionResult UserDetails(int id)
        {
            return View(repository.AllUsers.Find(x => x.UserId == id));
        }
    }
}
