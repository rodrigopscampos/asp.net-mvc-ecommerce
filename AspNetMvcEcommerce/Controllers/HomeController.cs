using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewBag.Categorias = _ctx.Categorias.ToList();
            ViewBag.Produtos = _ctx.Produtos.ToList();

            return View();
        }

        public ActionResult Sobre()
        {
            return View();
        }

        public ActionResult Contato()
        {
            return View();
        }
    }
}