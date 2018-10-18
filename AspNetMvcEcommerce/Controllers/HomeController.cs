using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            var produtos = _ctx.Produtos.ToList();
            ViewBag.Produtos = produtos;
            ViewBag.Categorias = _ctx.Categorias.ToList();
            ViewBag.CarrinhoDeCompras = this.CarrinhoDeCompras;

            return View();
        }

        public ActionResult Categoria(string catName)
        {
            List<Produto> produtos;

            if (catName == "")
            {
                produtos = _ctx.Produtos.ToList();
            }
            else
            { 
                produtos = _ctx.Produtos.Where(p => p.Categoria.Descricao == catName).ToList();
            }

            ViewBag.Categorias = _ctx.Categorias.ToList();
            ViewBag.Produtos = produtos;
            ViewBag.CategoriaSelectionada = catName;

            return View("Index");
        }
        
        public ActionResult AdicionaAoCarrinho(int id)
        {
            var produto = _ctx.Produtos.FirstOrDefault(p => p.Id == id);
            this.CarrinhoDeCompras.AdicionaProduto(produto);

            return RedirectToAction("Index");
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