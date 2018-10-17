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

            return View();
        }

        public ActionResult Categoria(string categoria)
        {
            List<Produto> produtos;

            if (categoria == "")
            {
                produtos = _ctx.Produtos.ToList();
            }
            else
            { 
                produtos = _ctx.Produtos.Where(p => p.Categoria.Descricao == categoria).ToList();
            }

            ViewBag.Produtos = produtos;
            ViewBag.CategoriaSelectionada = categoria;

            return View("Index");
        }
        
        public ActionResult AdicionaAoCarrinho(int id)
        {
            var produto = _ctx.Produtos.FirstOrDefault(p => p.Id == id);

            if (produto != null)
            {
                var carrinho = _ctx.ShoppingCartDatas.FirstOrDefault(c => c.Id == id);
                if (carrinho != null)
                {
                    carrinho.Quantidade++;
                }
                else
                {
                    carrinho = new CarrinhoDeComprasItem
                    {
                        NomeDoProduto = produto.Nome,
                        Id = produto.Id,
                        PrecoUnitario = produto.Preco,
                        Quantidade = 1
                    };

                    _ctx.ShoppingCartDatas.Add(carrinho);
                }
                
                _ctx.SaveChanges();
            }

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