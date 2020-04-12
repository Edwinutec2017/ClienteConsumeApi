using Dto.Dto.Login;
using Dto.Url;
using System;
using System.Web.Mvc;

namespace ClientePolicomerce.Controllers
{
    public class RegistroController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            UrlMethodos urlMethodos = new UrlMethodos(null);
            ViewBag.DepyMuni = urlMethodos.Departamento_Municipio(); 
            return View();
        }

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

        [HttpPost]
        public ActionResult ValidarUsuario(string usuario)
        {

            ActionResult result;
            UrlMethodos urlMethodos = new UrlMethodos(null);
            var obj = urlMethodos.ValidarUser(usuario);
            result = Json(obj);
            return result;
        }

    
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
    }
}
