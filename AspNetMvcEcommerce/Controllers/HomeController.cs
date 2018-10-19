using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class HomeController : BaseController
    {
        public ActionResult Index(string categoria)
        {
            ViewBag.Categorias = _ctx.Categorias.ToList();
            ViewBag.CarrinhoDeCompras = this.CarrinhoDeCompras;
            ViewBag.CategoriaSelectionada = categoria;

            if (string.IsNullOrWhiteSpace(categoria))
            {
                ViewBag.Produtos = _ctx.Produtos.ToList();
            }
            else
            {
                ViewBag.Produtos = _ctx.Categorias
                                        .Single(c => c.Descricao == categoria)
                                        .Produtos
                                        .ToList();
            }

            return View();
        }

        public ActionResult AdicionaAoCarrinho(int id, string categoria)
        {
            var produto = _ctx.Produtos.FirstOrDefault(p => p.Id == id);
            this.CarrinhoDeCompras.AdicionaProduto(produto);

            return RedirectToAction(nameof(Index), new { categoria = categoria });
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