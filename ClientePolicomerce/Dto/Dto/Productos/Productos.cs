using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Dto.Productos
{
    #region PRODUTOS Y SERVICIOS
    public class Productos
    {

            public int Codigo { get; set; }
            public string Categoria { get; set; }
            public string Descripcion { get; set; }
            public string Imagen { get; set; }
            public string Nombre { get; set; }
            public decimal Precio { get; set; }      
    }
    #endregion
    #region PARA DOCUMENTO Y TIPO PAGO
    public class DocumentoyPago
    {
        public int CODIGO { get; set; }
        public string NOMBRE { get; set; }
    }
    #endregion
    #region PARA NUMERO MAXIMO Y GENERAR EL CODIGO PEDIDO
    public class NumPedido
    {
        public int NumeroPedido { get; set; }

    }
    #endregion
    #region DETALLE PEDIDO
    public class DetallePedido {
        public int CodigoArticulo { get; set; }
        public int Cantidad { get; set; }
        public int IdEncabezado { get; set; }
        public double Precio { get; set; }
        public double TotalArticulo { get; set; }
    }
    #endregion
    #region Encabezado Pedido
    public class EncabezadoPedido
    {
        public int IdUser { get; set; }
        public int IdTipoPago { get; set; }
        public int IdTipoDoc { get; set; }
        public double MontoTotal { get; set; }

    }
    #endregion
    public class Codigo {
        public string CODIGOPEDIDO { get; set; }
    }

}
