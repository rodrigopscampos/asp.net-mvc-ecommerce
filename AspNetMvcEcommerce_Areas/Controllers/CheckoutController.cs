﻿using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class CheckoutController : BaseController
    {
        // GET: Checkout
        public ActionResult Index(string acao = null, int? produtoId = null)
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
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest, $"ação '{acao}' inválida");
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

        [Authorize]
        public ActionResult Continuar()
        {
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
        public ActionResult Continuar(Models.CheckoutDetalhesViewModel detalhes)
        {
            if (ModelState.IsValid)
            {
                if (detalhes.CcValidade <= DateTime.Now)
                {
                    ModelState.AddModelError("", "Cartão de crédito expirado");
                }

                if (ModelState.IsValid)
                {
                    var ordem = new Ordem
                    {
                        DataDeCriacao = DateTime.Now,
                        DataDeEntrega = DateTime.Now.AddDays(5),
                        ClienteId = User.Identity.GetUserId(),
                        Endereco = detalhes.Endereco,
                        CEP = detalhes.CEP,
                        CcNumero = detalhes.CcNumero,
                        CcValidade = detalhes.CcValidade,
                        OrdemItems = CarrinhoDeCompras.Itens.Values.Select(i => new OrdemItem
                        {
                            Preco = i.PrecoTotal,
                            ProdutoId = i.ProdutoId,
                            Quantidade = i.Quantidade
                        }).ToArray()
                    };

                    _ctx.Ordens.Add(ordem);
                    _ctx.SaveChanges();

                    CarrinhoDeCompras.Limpar();

                    return RedirectToAction("CompraRealizadaComSucesso", new { ordemId = ordem.Id } );
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

            return View(detalhes);
        }

        public ActionResult CompraRealizadaComSucesso(int ordemId)
        {
            var ordem = _ctx.Ordens
                    .Include(o => o.Cliente)
                    .Include(o => o.OrdemItems.Select(i => i.Produto))
                    .FirstOrDefault(o => o.Id == ordemId);

            return View(ordem);
        }
    }
}