using ClientePolicomerce.ViewModels.Login;
using Dto.Dto.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientePolicomerce.Controllers
{
    public class LoginController : Controller
    {
     
        public LoginController()
        {



        }

        public ActionResult Index()
        {
            ActionResult result = null;
            var user = (Session == null) ? null : (Session["User"] as LoginDto);
             result = (user == null) ? View() : View("MainPage");
             return result;

        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Usuario usuario)
        {
            ActionResult result;
            try {
                if (usuario !=null) {
                    if (usuario.User.Equals("a1") && usuario.Password.Equals("123"))
                    {
                        Session["User"] = new LoginDto { Id = 1, User = "a1" };
                        TempData["msg"] = "Exito correcto";
                        result = RedirectToAction("Index", "Home");
                    }
                    else {
                        TempData["msg"] = "Error de Credenciales";
                        result = View();
                    }
                 
                }
                else {
                    TempData["msg"] = "Campos Vacios..";
                    result = View();
                }
                return result;
            }
            catch (Exception ) {
                return View();
            }
            
        }

        public ActionResult Registro()
        {
            return View();
        }

        public ActionResult CerrarSession()
        {
            Session["User"] = null;
            Session.Remove("User");
            
            return RedirectToAction("Index", "Login"); ;
        }
    }
}