using Newsletter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Newsletter.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        
        public ActionResult Index()
        {
            ApplicationDbContext applicationUsers = new ApplicationDbContext();

            var user = UserManager.FindById(User.Identity.GetUserId());

            var userIsSub = applicationUsers.Users.First(x => x.isSub);

            return View();
        }
    }
}