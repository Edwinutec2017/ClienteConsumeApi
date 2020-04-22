﻿using Dto.Dto.Login;
using Dto.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClientePolicomerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ActionResult result;
            if (!(Session["User"] is LoginDto)) {
                Session.Timeout = 90000;
                result = RedirectToAction("Index", "Login");
            }
            else
                result = View();
            return result;
        }

        public ActionResult Productos()
        {
           UrlMethodos urlMethodos = new UrlMethodos(null);
           ViewBag.Productos = urlMethodos.Productos();
            return View();
        }

        public ActionResult Servicios()
        {
            UrlMethodos urlMethodos = new UrlMethodos(null);
            ViewBag.Servicios = urlMethodos.Servicios();

            return View();
        }
    }
}