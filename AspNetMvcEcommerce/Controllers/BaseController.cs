using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class BaseController : Controller
    {
        protected AspNetMvcEcommerceContext _ctx = new AspNetMvcEcommerceContext();

        public BaseController()
        {
            ViewBag.CartTotalPrice = PrecoTotalDoCarrinho;
            ViewBag.CarrinhoDeCompras = CarrinhoDeCompras;
            ViewBag.CartUnits = CarrinhoDeCompras.Count;
        }

        private List<CarrinhoDeComprasItem> CarrinhoDeCompras
        {
            get
            {
                return _ctx.ShoppingCartDatas.ToList();
            }
        }

        private decimal PrecoTotalDoCarrinho
        {
            get
            {
                return CarrinhoDeCompras.Sum(c => c.Quantidade * c.PrecoUnitario);
            }
        }
    }
}