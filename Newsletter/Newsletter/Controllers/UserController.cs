using Microsoft.AspNet.Identity;
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
            var user = applicationUsers.Users.First(x => x.Id == User.Identity.GetUserId());

            return View(model : user);
        }
        
        public void StartSubscrition()
        {
            ApplicationDbContext applicationUsers = new ApplicationDbContext();
            var currentUser = applicationUsers.Users.First(x => x.Id == User.Identity.GetUserId());

            //currentUser.isSub = true;


        }
    }
}