using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task1.Areas.Admin.Controllers
{
    [Authorize]
    public class AllUsersController : Controller
    {
        // GET: Admin/AllUsers
        public ActionResult Index()
        {
            return View(HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>().Users.ToList());
        }
    }
}