using AspNetMvcEcommerce.Models;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class BaseController : Controller
    {
        protected AspNetMvcEcommerceContext _ctx = new AspNetMvcEcommerceContext();

        protected CestaDeCompra CarrinhoDeCompras
        {
            get
            {
                if (Session["cesta"] == null)
                    Session.Add("cesta", new CestaDeCompra());

                return (CestaDeCompra)Session["cesta"];
            }
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            ViewBag.UsuarioAdmin = User.IsInRole("admin");
            ViewBag.CarrinhoDeCompras = this.CarrinhoDeCompras;

            base.OnActionExecuting(filterContext);
        }
    }
}