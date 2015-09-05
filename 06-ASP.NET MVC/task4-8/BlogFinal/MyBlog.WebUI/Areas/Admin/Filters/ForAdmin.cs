using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace MyBlog.WebUI.Areas.Admin.Filters
{
    public class ForAdmin : FilterAttribute, IActionFilter
    {
    
        #region IActionFilter Members

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
 	        //throw new NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
 	        if (!filterContext.HttpContext.Request.IsAuthenticated || !Roles.IsUserInRole("Admin"))
            {
                filterContext.Result = new HttpNotFoundResult("page dosen't exist");
            }
        }

        #endregion
        }
}