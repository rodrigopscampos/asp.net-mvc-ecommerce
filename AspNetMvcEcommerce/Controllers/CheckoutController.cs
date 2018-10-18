using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class CheckoutController : BaseController
    {
        // GET: Checkout
        public ActionResult Index(string acao, int? produtoId)
        {
            if (produtoId.HasValue)
            {
                var produto = CarrinhoDeCompras.GetItem(produtoId.Value);
                switch (acao)
                {
                    case "incrementar":
                        produto.Quantidade++;
                        CarrinhoDeCompras.SetItem(produto);
                        break;

                    case "decrementar":
                        produto.Quantidade--;
                        CarrinhoDeCompras.SetItem(produto);

                        if (produto.Quantidade == 0)
                            CarrinhoDeCompras.Remove(produtoId.Value);

                        break;

                    case "remover":
                        CarrinhoDeCompras.Remove(produtoId.Value);
                        break;

                    default:
                        throw new Exception("Acao não encontrada");
                }
            }

            ViewBag.CarrinhoDeCompras = CarrinhoDeCompras;
            return View(CarrinhoDeCompras);
        }

        public ActionResult Limpar()
        {
            try
            {
                this.CarrinhoDeCompras.Limpar();
                //List<CarrinhoDeComprasItem> carts = _ctx.ShoppingCartDatas.ToList();
                //_ctx.ShoppingCartDatas.RemoveRange(carts);
                //_ctx.SaveChanges();
            }
            catch (Exception) { }
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Continuar()
        {
            //ViewBag.States = states;
            //ViewBag.Cards = cards;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Continuar(Models.Cliente customer)
        {
            //ViewBag.States = states;
            //ViewBag.Cards = cards;

            if (ModelState.IsValid)
            {
                if (customer.CcValidade <= DateTime.Now)
                {
                    ModelState.AddModelError("", "Cartão de crédito expirado");
                }

                if (ModelState.IsValid)
                {
                    Cliente c = new Cliente
                    {
                        Nome = customer.Nome,
                        Email = customer.Email,
                        Phone = customer.Phone,
                        Endereco = customer.Endereco,
                        Bairro = customer.Bairro,
                        CEP = customer.CEP,
                        Estado = customer.Estado,
                        CcNumero = customer.CcNumero,
                        CcValidade = customer.CcValidade
                    };

                    Ordem o = new Ordem
                    {
                        DataDeCriacao = DateTime.Now,
                        DataDeEntrega = DateTime.Now.AddDays(5),
                        ClienteId = c.Id
                    };

                    _ctx.Clientes.Add(c);
                    _ctx.Ordens.Add(o);

                    //foreach (var i in _ctx.ShoppingCartDatas.ToList<CarrinhoDeComprasItem>())
                    //{
                    //    _ctx.IrdemItens.Add(new OrdemItem
                    //    {
                    //        OrdemId = o.ItensId,
                    //        Id = i.Id,
                    //        Quantidade = i.Quantidade,
                    //        ValorTotal = i.Quantidade * i.PrecoUnitario
                    //    });
                    //    _ctx.ShoppingCartDatas.Remove(i);
                    //}

                    _ctx.SaveChanges();

                    return RedirectToAction("CompraRealizadaComSucesso");
                }
            }

            List<ModelError> errors = new List<ModelError>();
            foreach (ModelState modelState in ViewData.ModelState.Values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    errors.Add(error);
                }
            }
            return View(customer);
        }

        public ActionResult CompraRealizadaComSucesso()
        {
            return View();
        }
    }
}
