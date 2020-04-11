using Dto.Dto.Departamento;
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
        #region login
        public List<LoginDto> ValidarLogin()
        {
            try
            {
                List<LoginDto> loginDto = null;
                var result1 = Post();
                if (result1.IsSuccessStatusCode)
                {
                  
                    loginDto = result1.Content.ReadAsAsync<List<LoginDto>>().Result;
                }
                return loginDto;
            }
            catch (Exception ex) {
                Console.WriteLine($"Erro Validar Login..{ex.StackTrace}");
                return null;
            }

        }
        #endregion
        #region departamentos
        public List<DepyMuni> Departamento_Municipio()
        {
           
            try
            {
                List<DepyMuni> Dep = null;
                var result1 = Get();
                if (result1.IsSuccessStatusCode)
                {
                   
                    Dep = result1.Content.ReadAsAsync<List<DepyMuni>>().Result;
                }
                return Dep;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error traer departamentos.. {ex.StackTrace} ");
                return null;
            }

        }
        #endregion
        #region validar usuario
        public int ValidarUser()
        {

            try
            {
                List<ValidarUser> usua = new List<ValidarUser>(); 
                var result1 = Get();
                if (result1.IsSuccessStatusCode)
                {

                    usua= result1.Content.ReadAsAsync<List<ValidarUser>>().Result;
                    
                }
                return usua.Count() > 0 ? 200 : 400;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validar usuario.. {ex.StackTrace} ");
                return 500;
            }

        }
        #endregion

        #region Registro Usuario
        public int RegistroUsuario()
        {

            try
            {
                RespRegistro usua = new RespRegistro();
                var result1 = Post();
                if (result1.IsSuccessStatusCode)
                {

                    usua = result1.Content.ReadAsAsync<RespRegistro>().Result;

                }
                return usua.Status == "200" ? 200 : 400;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error validar usuario.. {ex.StackTrace} ");
                return 500;
            }

        }
        #endregion

        #region METODOS URL
        private HttpResponseMessage Post() {

            return client.PostAsJsonAsync(ulrApi, obj).Result;
        }

        private HttpResponseMessage Get()
        {
            return client.GetAsync(ulrApi).Result;

        }
        #endregion

    }
}
