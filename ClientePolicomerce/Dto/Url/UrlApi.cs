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
            return $"{host}ords/policomerce/policomerce/login";
        }
        public string UrlDepartamento()
        {
            return $"{host}ords/policomerce/policomerce/departamento/"; ;
        }
        public string UrlMunicipio(int id)
        {
            return $"{host}ords/policomerce/policomerce/municipios/?ID={id}"; ;
        }
        public string UrlValidarUsuario(string nombre)
        {
            return $"{host}ords/policomerce/policomerce/usuarios/?USUARIO={nombre}"; ;
        }
        public string UrlCrearUsuario() {
            return $"{host}ords/policomerce/policomerce/usuarios/";
        }
        public string UrlListaProductos() {
            return $"{host}ords/policomerce/policomerce/articulos/";
        }
        public string UrlListaServicios() {
            return $"{host}ords/policomerce/policomerce/servicios/";
        }

    }
}

