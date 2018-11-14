using Razor.Models;
using System;
using System.Web.Mvc;

namespace Razor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Data = DateTime.Now;
            ViewBag.Autenticado = true;
            ViewBag.Usuario = "Fulano";

            var model = new HomeViewModel { Mensagem = "Olá Mundo" };

            return View(model);
        }
    }
}