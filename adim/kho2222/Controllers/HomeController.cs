using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using kho2222.Models;
namespace kho2222.Controllers
{
    public class HomeController : Controller
    {
        private kho2Entities db = new kho2Entities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(string user_name, string pass_word)
        {
            if (user_name != null)
            {
                var usr = db.tks
                    .Where(m => m.tk1.Equals(user_name))
                    .Where(m => m.mk.Equals(pass_word))
                    .Where(m => m.chucvu.Equals("Admin"))
                    .FirstOrDefault();
                if (usr != null)
                {
                    Session["tk"] = usr.tk1;
                    Session["mk"] = usr.mk;
                    if (Session["URL"] != null)
                    {
                        return Redirect(Session["URL"].ToString());
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                }

            }
            return View();
        }
        public ActionResult logout()
        {
            Session["tk"] = null;
            Session["mk"] = null;
            return RedirectToAction("login");
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}