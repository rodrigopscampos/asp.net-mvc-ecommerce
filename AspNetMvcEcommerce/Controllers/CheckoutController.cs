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
            this.CarrinhoDeCompras.Limpar();
            return RedirectToAction("Index", "Home", null);
        }

        public ActionResult Continuar()
        {
            ViewBag.CarrinhoDeCompras = CarrinhoDeCompras;

            ViewBag.Estados = new[]
           {
                new SelectListItem { Value = "SP",  Text = "São Paulo", Selected = true },
                new SelectListItem { Value = "RJ",  Text = "Rio de Janeiro" },
                new SelectListItem { Value = "MG",  Text = "Minas Gerais"   }
            };

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Continuar(Models.Cliente customer)
        {
            ViewBag.CarrinhoDeCompras = CarrinhoDeCompras;

            ViewBag.Estados = new[]
            {
                new SelectListItem { Value = "SP",  Text = "São Paulo", Selected = true },
                new SelectListItem { Value = "RJ",  Text = "Rio de Janeiro" },
                new SelectListItem { Value = "MG",  Text = "Minas Gerais"   }
            };

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
                        CEP = customer.CEP,
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

                    return RedirectToAction("CompraRealizadaComSucesso");
                }
            }

            var errors = new List<ModelError>();
            foreach (var modelState in ViewData.ModelState.Values)
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
            ViewBag.CarrinhoDeCompras = CarrinhoDeCompras;
            return View(CarrinhoDeCompras);
        }
    }
}