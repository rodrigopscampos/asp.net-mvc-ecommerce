using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class HomeController : BaseController
    {
        
        public ActionResult Index()
        {

            List<Produto> products = _ctx.Products.ToList<Produto>();
            ViewBag.Products = products;
            return View();
        }

        public ActionResult Category(string catName)
        {
            List<Produto> products;
            if (catName == "")
            {
                products = _ctx.Products.ToList();
            } else { 
                products = _ctx.Products.Where(p => p.Category == catName).ToList<Produto>();
            }
            ViewBag.Products = products;
            return View("Index");
        }
        
        public ActionResult AddToCart(int id)
        {
            addToCart(id);
            return RedirectToAction("Index");
        }

        private void addToCart(int pId)
        {
            // check if product is valid
            var product = _ctx.Products.FirstOrDefault(p => p.Id == pId);

            if (product != null && product.UnitsInStock > 0)
            {
                // check if product already existed
                ShoppingCartData cart = _ctx.ShoppingCartDatas.FirstOrDefault(c => c.Id == pId);
                if (cart != null)
                {
                    cart.Quantity++;
                }
                else
                {

                    cart = new ShoppingCartData
                    {
                        PName = product.PName,
                        Id = product.Id,
                        UnitPrice = product.UnitPrice,
                        Quantity = 1
                    };

                    _ctx.ShoppingCartDatas.Add(cart);
                }
                product.UnitsInStock--;
                _ctx.SaveChanges();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}