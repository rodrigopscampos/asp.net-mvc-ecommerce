using System;
using System.Collections.Generic;
using System.Linq;
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
            ViewBag.CarrinhoDeCompras = _ctx.ShoppingCartDatas.ToList<CarrinhoDeComprasItem>();
            return View();
        }
        
        public JsonResult AtualizaQuantidade(int type, int pId)
        {
            AspNetMvcEcommerceContext context = new AspNetMvcEcommerceContext();

            CarrinhoDeComprasItem product = context.ShoppingCartDatas.FirstOrDefault(p => p.Id == pId);
            if (product == null)
            {
                return Json(new { d = "0" });
            }

            Produto actualProduct = context.Produtos.FirstOrDefault(p => p.Id == pId);
            int quantity;

            if (product.Quantidade == 0)
            {
                context.ShoppingCartDatas.Remove(product);
                quantity = 0;
            }
            else
            {
                quantity = product.Quantidade;
            }

            context.SaveChanges();
            return Json(new { d = quantity });
        }
        
        [HttpGet]
        public JsonResult AtualizaTotal()
        {
            AspNetMvcEcommerceContext context = new AspNetMvcEcommerceContext();
            decimal total;
            try
            {

                total = context.ShoppingCartDatas.Select(p => p.PrecoUnitario * p.Quantidade).Sum();
            }
            catch (Exception) { total = 0; }

            return Json(new { d = String.Format("{0:c}", total) }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Limpar()
        {
            try
            {
                List<CarrinhoDeComprasItem> carts = _ctx.ShoppingCartDatas.ToList();
                _ctx.ShoppingCartDatas.RemoveRange(carts);
                _ctx.SaveChanges();
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

                    foreach (var i in _ctx.ShoppingCartDatas.ToList<CarrinhoDeComprasItem>())
                    {
                        _ctx.IrdemItens.Add(new OrdemItem
                        {
                            OrdemId = o.ItensId,
                            Id = i.Id,
                            Quantidade = i.Quantidade,
                            ValorTotal = i.Quantidade * i.PrecoUnitario
                        });
                        _ctx.ShoppingCartDatas.Remove(i);
                    }

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
