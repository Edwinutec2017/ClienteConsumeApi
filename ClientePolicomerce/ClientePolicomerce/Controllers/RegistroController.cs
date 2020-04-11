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
            UrlApi urlApi = new UrlApi();
            UrlMethodos urlMethodos = new UrlMethodos(urlApi.UrlDepartamento(),null);
            ViewBag.DepyMuni = urlMethodos.Departamento_Municipio(); 
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Index(Registro registro)
        {
            ActionResult result;
            UrlApi urlApi = new UrlApi();
            UrlMethodos urlMethodos = new UrlMethodos(urlApi.CrearUsuario(), registro);
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
            UrlApi urlApi = new UrlApi();
            UrlMethodos urlMethodos = new UrlMethodos(urlApi.ValidarUsuario(usuario), null);
            var obj = urlMethodos.ValidarUser();
            result = Json(obj);
            return result;
        }

    
        [HttpPost]
        public ActionResult Municipios(int iddep)
        {
          ActionResult result;
          UrlApi urlApi = new UrlApi();
          UrlMethodos urlMethodos = new UrlMethodos(urlApi.UrlMunicipio(iddep), null);
           var obje = urlMethodos.Departamento_Municipio();
            result = Json(obje);
            return result;
        }
    }
}
