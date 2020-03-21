﻿using System;
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
            var url = $"{host}ords/policomerce/policomerce/municipios/{id}";
            return url;

        }
    }
}
}
