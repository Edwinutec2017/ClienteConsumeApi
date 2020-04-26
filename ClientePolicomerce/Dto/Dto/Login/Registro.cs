
namespace Dto.Dto.Login
{
    #region REGISTRO USUARIO
    public class Registro
    {
  
        public string APELLIDO1 { get; set; }
        public string APELLIDO2 { get; set; }
        public string CLAVE { get; set; }
        public string CORREO { get; set; }
        public string DIRECCION { get; set; }
        public int EDAD { get; set; }
        public char GENERO { get; set; }
        public int IDMUNICIPIO { get; set; }
        public string NOMBRE1 { get; set; }
        public string NOMBRE2 { get; set; }
        public int TELEFONO { get; set; }
        public string USUARIO { get; set; }
    }
    #endregion
    #region RESPUESTA SI EL USUARIO FUE REGISTRADO
    public class RespRegistro
    {
        public string Status { get; set; }

    }
    #endregion
    #region VALIDAR USUARIO NO SE REPITA
    public class ValidarUser
    {
        public string USUA { get; set; }

    }
    #endregion
}
