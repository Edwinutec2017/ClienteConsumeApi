
namespace Dto.Dto.Login
{
    #region DATOS USUARIO A DB
    public class LoginUser
    {
        public string Clave { get; set; }
        public string Usuario { get; set; }
    }
    #endregion
    #region DATOS DE LA DB DEL USUARIO
    public class LoginDto
    {
        public int Codigo { get; set; }
        public string Nombre { get; set; }

    }
    #endregion
}
