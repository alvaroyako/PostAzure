using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PostAzure.Models;
using PostAzure.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PostAzure.Controllers
{
    public class HomeController : Controller
    {
        private ServiceMail service;

        public HomeController(ServiceMail service)
        {
            this.service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string email,string asunto,string mensaje)
        {
            Correo correo = new Correo();
            correo.Email = email;
            correo.Asunto = asunto;
            correo.Mensaje = mensaje;

            await this.service.SendMail(correo);
            ViewData["MENSAJE"] = "Correo enviado con exito";

            return View();
        }

       
    }
}
