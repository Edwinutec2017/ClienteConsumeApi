﻿using Dto.Dto.Departamento;
using Dto.Dto.Login;
using Dto.Dto.Productos;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Dto.Url
{

    public class UrlMethodos
    {
        #region ATRIBUTOS
        private static HttpClient client = new HttpClient();
        private  string urlApi;
        private static  object obj;
        private static object ObjResp { set; get; }
        private UrlApi api;
        #endregion

        #region CONSTRUCTOR
        public UrlMethodos(object _objeto)
        {
            obj = _objeto;
            api = new UrlApi();
        }
        #endregion

        #region login
        public List<LoginDto> ValidarLogin()
        {
            urlApi = api.UrlLogin();
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
            urlApi = api.UrlDepartamento();
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
        #region departamentos
        public List<DepyMuni> Municipio(int iddep)
        {
            urlApi = api.UrlMunicipio(iddep);
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
        public int ValidarUser(string usuario)
        {
            urlApi = api.UrlValidarUsuario(usuario);
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
            urlApi = api.UrlCrearUsuario();
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
        #region PRODUCTOS TODOS
        public List<Productos> Productos() {

            try {
                urlApi = api.UrlListaProductos();

                List<Productos> _producto = new List<Productos>();
                var result = Get();

                if (result.IsSuccessStatusCode)
                {
                    _producto = result.Content.ReadAsAsync<List<Productos>>().Result;

                }
                return _producto;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error traer productos.. {ex.StackTrace} ");
                return null;
            }
         
        }
        #endregion
        #region SERVICIOS TODOS
        public List<Productos> Servicios() {
            try {
                List<Productos> _servicicio = new List<Productos>();
                urlApi = api.UrlListaServicios();
                var result = Get();
                if (result.IsSuccessStatusCode) {
                    _servicicio = result.Content.ReadAsAsync<List<Productos>>().Result;
                }
                return _servicicio;
            }
            catch (Exception ex) {
                Console.WriteLine($"Error al Traer Servicios {ex.StackTrace}");
                return null;
            }

        }
        #endregion
        #region TIPO PAGO
        public List<DocumentoyPago> TipoPago()
        {
            List<DocumentoyPago> _pago = new List<DocumentoyPago>();
            try
            {
                
                urlApi = api.UrlTipoPago();
                var result = Get();
                if (result.IsSuccessStatusCode)
                {
                    _pago = result.Content.ReadAsAsync<List<DocumentoyPago>>().Result;
                    if (_pago.Equals(null)) {
                        _pago = null;
                    }

                }
                return _pago;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al Traer Servicios {ex.StackTrace}");
                return null;
            }

        }
        #endregion
        #region TIPOD DOCUMENTP
        public List<DocumentoyPago> TipoDocuemto()
        {
            List<DocumentoyPago> _doc = new List<DocumentoyPago>();
            try
            {
                
                urlApi = api.UrlTipoDocumento();
                var result = Get();
                if (result.IsSuccessStatusCode)
                {
                    _doc = result.Content.ReadAsAsync<List<DocumentoyPago>>().Result;
                   if (_doc.Equals(null))
                    {
                        _doc = null;
                    }
                }
                return _doc;
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al Traer Servicios {ex.StackTrace}");
                _doc = null;
                return null;
            }

        }
        #endregion
        #region NUMERO MAX PEDIDO
        public NumPedido NumeroMax()
        {
            NumPedido _num = new NumPedido();
            try
            {

                urlApi = api.UrlTipoDocumento();
                var result = Get();
                if (result.IsSuccessStatusCode)
                {
                    _num = result.Content.ReadAsAsync<NumPedido>().Result;

                }
                return _num;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al Traer Servicios {ex.StackTrace}");
                _num = new NumPedido()
                {
                    NumeroPedido = 1
                };
                return _num;
            }

        }
        #endregion



        #region METODOS URL
        private HttpResponseMessage Post() {

            return client.PostAsJsonAsync(urlApi, obj).Result;
        }

        private HttpResponseMessage Get()
        {
            return client.GetAsync(urlApi).Result;

        }
        #endregion

    }
}
