using Dto.Dto.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Dto.Url
{

    public class UrlMethodos
    {
        #region ATRIBUTOS
        private static HttpClient client = new HttpClient();
        private static string ulrApi;
        private static  object obj;
        private static object ObjResp { set; get; }
        #endregion
        #region CONSTRUCTOR
        public UrlMethodos(string _api,object _objeto)
        {
            ulrApi = _api;
            obj = _objeto;
         
        }
        #endregion

        public List<LoginDto> ValidarLogin()
        {
            List<LoginDto> loginDto=null;
            var result1 = Post();
            if (result1.IsSuccessStatusCode)
            {
                loginDto = result1.Content.ReadAsAsync<List<LoginDto>>().Result;
            }
            return loginDto;

        }

        private HttpResponseMessage Post() {

            return client.PostAsJsonAsync(ulrApi, obj).Result;
        }
    }
}
