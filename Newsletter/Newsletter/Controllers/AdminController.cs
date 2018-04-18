using Newsletter.Models;
using System.Collections.Generic;
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
                if (user.isSub)
                {
                    emails.Add(user.Email);
                }
            }

            return View(model : emails);
        }
    }
}