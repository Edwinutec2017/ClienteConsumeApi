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
        

    }
}
