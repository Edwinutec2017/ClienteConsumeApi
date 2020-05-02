using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Url
{
    public class UrlApi
    {
        #region HOST
        private readonly string host = "http://localhost:8080/";
       //private readonly string host = "http://192.168.56.5:8080/";
        #endregion

        #region UrlLogin
        public string UrlLogin()
        {
            return $"{host}ords/policomerce/policomerce/login";
        }
        #endregion
        #region UrlDepartamento
        public string UrlDepartamento()
        {
            return $"{host}ords/policomerce/policomerce/departamento/"; ;
        }
        #endregion
        #region UrlMunicipio
        public string UrlMunicipio(int id)
        {
            return $"{host}ords/policomerce/policomerce/municipios/?ID={id}"; ;
        }
        #endregion
        #region UrlValidarUsuario
        public string UrlValidarUsuario(string nombre)
        {
            return $"{host}ords/policomerce/policomerce/usuarios/?USUARIO={nombre}"; ;
        }
        #endregion
        #region UrlCrearUsuario
        public string UrlCrearUsuario() {
            return $"{host}ords/policomerce/policomerce/usuarios/";
        }
        #endregion
        #region UrlListaProductos
        public string UrlListaProductos() {
            return $"{host}ords/policomerce/policomerce/articulos/";
        }
        #endregion
        #region UrlListaServicios
        public string UrlListaServicios() {
            return $"{host}ords/policomerce/policomerce/servicios/";
        }
        #endregion
        #region UrlTipoPago
        public string UrlTipoPago() {
            return $"{host}ords/policomerce/policomerce/tipopago/";
        }
        #endregion
        #region UrlTipoDocumento
        public string UrlTipoDocumento() {
            return $"{host}ords/policomerce/policomerce/documento/";
        }
        #endregion
        #region UrlCodigoPedido
        public string UrlCodigoPedido()
        {
            return $"{host}ords/policomerce/policomerce/numpedid";
        }
        #endregion
        #region UrlEncabezado
        public string UrlEncabezadoPedido() {
            return $"{host}ords/policomerce/policomerce/encabezadopedido/";
        }
        #endregion
        #region Busca Id Pedido
        public string UrlIdPedido(string codigo) {
            return $"{host}ords/policomerce/policomerce/encabezadopedido/?cod={codigo}";
        }
        #endregion
        #region UrlPedidoDetalle
        public string UrlDetallePedido()
        {
            return $"{host}ords/policomerce/policomerce/pedidodetalle/";
        }
        #endregion
        #region Mostrar Encabezado Pedido
        public string UrlPedidoEncabezado(int id) {
            return $"{host}ords/policomerce/policomerce/pedidos/?Id={id}";

        }
        #endregion
        #region ELIMINCION PEDIDO
        public string UrlPedidoCancelado(int id) {
            return $"{host}ords/policomerce/policomerce/pedidos/?Id={id}";
        }
        #endregion
        #region Mostrar Detalle Pedido
        public string UrlPedidoDetalle(int id) {
            return $"{host}ords/policomerce/policomerce/pedidodetalle/?Id={id}";

        }
        #endregion

    }
}

