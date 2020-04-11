using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Url
{
    public class UrlApi
    {
        private readonly string host = "http://localhost:8080/";

        public string UrlLogin()
        {
            var url =$"{host}ords/policomerce/policomerce/login";
            return url;
        }

      
        public string UrlDepartamento()
        {
            var url = $"{host}ords/policomerce/policomerce/departamento/";
            return url;

        }
      
        public string UrlMunicipio(int id)
        {
            var url = $"{host}ords/policomerce/policomerce/municipios/?ID={id}";
            return url;

        }

        public string ValidarUsuario(string nombre)
        {
            var url = $"{host}ords/policomerce/policomerce/usuarios/?USUARIO={nombre}";
            return url;

        }

        public string CrearUsuario() {
            var url =$"{host}ords/policomerce/policomerce/usuarios/";
            return url;
        }

    }
}

