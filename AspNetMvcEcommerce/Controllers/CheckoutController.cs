using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class CheckoutController : BaseController
    {
        private List<object> states;
        private List<object> cards;

        public CheckoutController()
        {
            states = new List<object> {
                new { SID = "NSW", SName = "New South Wales" },
                new { SID = "VIC", SName = "Victoria" },
                new { SID = "QLD", SName = "Queensland" },
                new { SID = "TAs", SName = "Tasmania" },
                new { SID = "NT", SName = "Northern Territory" },
                new { SID = "SA", SName = "South Australia" },
                new { SID = "WA", SName = "Western Australia" },
                new { SID = "ACT", SName = "Australian Capital Territory" }
            };

            cards = new List<object> {
                new { Type = "VISA" },
                new { Type = "Master Card" },
                new { Type = "AMEX" }
            };

        }

        // GET: Checkout
        public ActionResult Index()
        {
            ViewBag.CarrinhoDeCompras = this.CarrinhoDeCompras;
            return View();
        }

        public JsonResult AtualizaQuantidade(string acao, int id)
        {
            var produto = CarrinhoDeCompras.GetItem(id);

            switch (acao)
            {
                case "incrementa":
                    produto.Quantidade++;
                    CarrinhoDeCompras.SetItem(produto);
                    return Json(new { quantidadeAtual = produto.Quantidade });

                case "decrementa":
                    produto.Quantidade--;
                    CarrinhoDeCompras.SetItem(produto);
                    return Json(new { quantidadeAtual = produto.Quantidade });

                case "remove":
                    CarrinhoDeCompras.Remove(id);
                    return Json(new { quantidadeAtual = 0 });

                default:
                    throw new Exception();
            }
        }

        [HttpGet]
        public JsonResult AtualizaTotal()
        {
            return Json(new { d = String.Format("{0:c}", CarrinhoDeCompras.PrecoTotal) }, JsonRequestBehavior.AllowGet);
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
            ViewBag.States = states;
            ViewBag.Cards = cards;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Continuar(Models.Cliente customer)
        {
            ViewBag.States = states;
            ViewBag.Cards = cards;

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
