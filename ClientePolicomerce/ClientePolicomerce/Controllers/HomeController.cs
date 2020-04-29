using Dto.Dto.Login;
using Dto.Dto.Productos;
using Dto.Url;
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


            if (!(Session["User"] is LoginDto))
            {
                Session.Timeout = 90000;

                result = RedirectToAction("Index", "Login");
            }
            else
                result = View();
            return result;
        }

        public ActionResult Productos()
        {
            UrlMethodos urlMethodos = new UrlMethodos(null);
            ViewBag.Productos = urlMethodos.Productos();
            ViewBag.tipoPago = urlMethodos.TipoPago();
            ViewBag.tipoDocumento = urlMethodos.TipoDocuemto();
            return View();
        }

        public ActionResult Servicios()
        {
            UrlMethodos urlMethodos = new UrlMethodos(null);
            ViewBag.Servicios = urlMethodos.Servicios();
            ViewBag.tipoPago = urlMethodos.TipoPago();
            ViewBag.tipoDocumento = urlMethodos.TipoDocuemto();
            return View();
        }
        [HttpPost]
        public ActionResult PedidosDetalle (IdPedidoClinte pedi) {
            UrlMethodos urlMethodos = new UrlMethodos(null);
            List<ClPedidoDetalle> det = urlMethodos.MostrarDetalle(pedi.Id);
            return Json(det.ToList());
        }
        public ActionResult PedidosSolic()
        {
            UrlMethodos urlMethodos = new UrlMethodos(null);
            var usuario = Session["User"] as LoginDto;
            ViewBag.Encabezado = urlMethodos.PedidoEncabezados(usuario.Codigo);
            return View();
        }

        [HttpPost]
        public ActionResult PedidoCancelar(IdPedidoClinte pedi)
        {
            ActionResult result;
            UrlMethodos urlMethodos = new UrlMethodos(null);
            Respuesta resp = urlMethodos.CancelarPedido(pedi.Id);
            result = Json(resp.Status);
         
            return result;
        }

        [HttpPost]
        public ActionResult Pedido(List<DetallePedido> array, EncabezadoPedido encabezado)
        {
            ActionResult resul;
            DetallePedido deta;
            var status = "400";
            if (array.Count <= 10 || encabezado != null)
            {
                List<IdPedido> id;
                UrlMethodos urlMethodos = new UrlMethodos(encabezado);
                Codigo cod = urlMethodos.RegistroEncabezadoPedido();
                if (!string.IsNullOrEmpty(cod.CODIGOPEDIDO))
                {
                    id = urlMethodos.IdPedido(cod.CODIGOPEDIDO);
                    if (id.Count > 0)
                    {
                        var idpedido = 0;
                        foreach (var idp in id)
                        {
                            idpedido = idp.CODIGOPEDIDO;
                        };

                        foreach (var det in array)
                        {
                            deta = new DetallePedido()
                            {
                                CodigoArticulo = det.CodigoArticulo,
                                Cantidad = det.Cantidad,
                                IdEncabezado = idpedido,
                                Precio = det.Precio,
                                TotalArticulo = det.TotalArticulo
                            };
                            urlMethodos = new UrlMethodos(deta);
                            Respuesta resp = urlMethodos.DetallePedido();
                            if (resp.Status.Equals("200"))
                                status =cod.CODIGOPEDIDO ;
                            else
                                status = "400";
                        }
                    }
                    else
                        status= "400";
                }
                else
                    status = "400";
            }
            else
                status = "400";

            resul = Json(status);

            return resul;

        }
    }
}