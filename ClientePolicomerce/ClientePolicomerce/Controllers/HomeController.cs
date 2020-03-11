using Dto.Dto.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientePolicomerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ActionResult result;
            if (!(Session["User"] is LoginDto a))
            {
                result = RedirectToAction("Index", "Login");
            }
            else
                result = View();
            return result;
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