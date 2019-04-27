using Action_Filter_sample_1.Models;
using Action_Filter_sample_1.Models.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Action_Filter_sample_1.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult SignIn()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult SignIn(User model)
        {
            DatabaseContext db = new DatabaseContext();
            User user_object = db.db_context_User.FirstOrDefault(x => x.User_username == model.User_username && x.User_password == model.User_password);

            if (user_object == null)
            {
                ModelState.AddModelError("", "Missing username or password.");
                return View(model);
            }
            else
            {
                Session["login"] = user_object;
                return RedirectToAction("Index", "Home");
            }


        }

        [HttpGet]
        public ActionResult Error()
        {
            if (TempData["error"] == null)
                return RedirectToAction("Index", "Home");

            Exception model = TempData["error"] as Exception;

            return View(model);
        }

    }
}