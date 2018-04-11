using Newsletter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Newsletter.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        
        public ActionResult Index()
        {
            List<string> emails = new List<string>();

            ApplicationDbContext applicationUsers = new ApplicationDbContext();

            foreach (ApplicationUser user in applicationUsers.Users)
            {
                emails.Add(user.Email); 
            }

            return View(model : emails);
        }
    }
}