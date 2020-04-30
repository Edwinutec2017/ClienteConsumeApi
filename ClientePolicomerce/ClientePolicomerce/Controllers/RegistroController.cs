using Dto.Dto.Login;
using Dto.Dto.Productos;
using Dto.Url;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ClientePolicomerce.Controllers
{
    public class RegistroController : Controller
    {
        #region INDEX
        [HttpGet]
        public ActionResult Index()
        {
            ActionResult result;
            try {
                UrlMethodos urlMethodos = new UrlMethodos(null);
                var dep = urlMethodos.Departamento_Municipio();
                if (dep.Count > 0)
                {
                    ViewBag.DepyMuni = dep;
                    result= View();
                }
                else {
          
                    TempData["msg"] = "Datos Para El Registro DE Usuario No Disponibles";
                    TempData["status"] = "Status: 200";
                    result = RedirectToAction("Error", "Login");
                }
            }
            catch (Exception ex) {
                Console.WriteLine($"Url No encontrada {ex.StackTrace}");
                TempData["msg"] = "Registro de Usuario No Disponible.";
                TempData["status"] = "Status: 400";
                result = RedirectToAction("Error", "Login"); 
            }

            return result;
        }
        #endregion
        #region REGISTRO USER
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Registro registro)
        {
            ActionResult result;
            UrlMethodos urlMethodos = new UrlMethodos( registro);
            var resp = urlMethodos.RegistroUsuario();
            if (resp == 200) 
                TempData["msg"] = "Usuario Creado Con Exito";
            else
                TempData["msg"] = "El Usuario No se Pudo Registrar";

            result = RedirectToAction("Index", "Registro");
            return result; 
        }
        #endregion
        #region VALIDAR USER
        [HttpPost]
        public ActionResult ValidarUsuario(string usuario)
        {

            ActionResult result;
            UrlMethodos urlMethodos = new UrlMethodos(null);
            var obj = urlMethodos.ValidarUser(usuario);
            result = Json(obj);
            return result;
        }
        #endregion
        #region LISTA DEPARTAMENTO
        [HttpPost]
        public ActionResult Municipios(int iddep)
        {
          ActionResult result;
          UrlApi urlApi = new UrlApi();
          UrlMethodos urlMethodos = new UrlMethodos(null);
            var obje = urlMethodos.Municipio(iddep);
            result = Json(obje);
            return result;
        }
        #endregion
    }
}
