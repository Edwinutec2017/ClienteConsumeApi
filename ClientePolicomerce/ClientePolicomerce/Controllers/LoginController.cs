using Dto.Dto.Login;
using Dto.Url;
using System;
using System.Collections.Generic;
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
        public ActionResult Index(LoginUser usr)
        {
            ActionResult result;
            try {
                if (usr != null) {
             
                        UrlApi api = new UrlApi();
                        LoginUser loginUser = usr;
                        UrlMethodos urlMethodos = new UrlMethodos(api.UrlLogin(),loginUser);
                       
                       List<LoginDto> datos = urlMethodos.ValidarLogin();
                    if (datos.Count > 0)
                    {
                        foreach (var user in datos) {

                            Session["User"] = new LoginDto { Codigo = user.Codigo, Nombre = user.Nombre };
                          
                        }
                      
                        result = RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["msg"] = "Error de autenticacion..";
                        result = View();
                    }
                    
                }
                else {
                    TempData["msg"] = "Campos Vacios..";
                    result = View();
                }
                return result;
            }
            catch (Exception ex ) {
                Console.WriteLine($"Error de Autenticacion {ex.StackTrace} ");
                return View();
            }
            
        }
        public ActionResult CerrarSession()
        {
            Session["User"] = null;
            Session.Remove("User");
            TempData["msg"] = "";
            return RedirectToAction("Index", "Login"); ;
        }
    }
}