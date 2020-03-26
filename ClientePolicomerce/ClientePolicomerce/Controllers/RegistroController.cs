using ClientePolicomerce.Extencion;
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
            return View();
        }
    }
}
