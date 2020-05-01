using Dto.Dto.Login;
using Dto.Url;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ClientePolicomerce.Controllers
{
    public class LoginController : Controller
    {
        #region Inicio
        public ActionResult Index()
        {
            ActionResult result = null;
            var user = (Session == null) ? null : (Session["User"] as LoginDto);
             result = (user == null) ? View() : View("MainPage");
             return result;

        }
        #endregion
        #region VALIDACION USUARIOS
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginUser usr)
        {
            ActionResult result;
            try {
                if (usr != null) {
             
                  LoginUser loginUser = usr;
                   UrlMethodos urlMethodos = new UrlMethodos(loginUser);
                   List<LoginDto> datos = urlMethodos.ValidarLogin();
                    if (datos.Count > 0)
                    {
                        foreach (var user in datos) {

                            Session["User"] = new LoginDto { Codigo = user.Codigo, Nombre = user.Nombre };
                            Session.Timeout = 90000;
                        }
                      
                        result = RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        TempData["msg"] = "Error de autenticacion.. Credenciales Incorrectas o no tiene permiso..";
                        TempData["status"] = "Status:200.";
                        result = RedirectToAction("Error", "Login"); ;
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
                TempData["msg"] = "Servicio de autenticacion Inaccesible.";
                TempData["status"] = "Status:400.";
                result = RedirectToAction("Error", "Login"); ;
                return result;
            }
            
        }
        #endregion
        #region CERRAR SESSION
        public ActionResult CerrarSession()
        {
            Session["User"] = null;
            Session.Remove("User");
            TempData["msg"] = "";
            return RedirectToAction("Index", "Login"); ;
        }
        public ActionResult Error() {
            
            return View();
        }
        #endregion
    }
}