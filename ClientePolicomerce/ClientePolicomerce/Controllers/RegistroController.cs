using Dto.Dto.Login;
using System.Web.Mvc;

namespace ClientePolicomerce.Controllers
{
    public class RegistroController : Controller
    {
        
        public ActionResult Index()
        {
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
