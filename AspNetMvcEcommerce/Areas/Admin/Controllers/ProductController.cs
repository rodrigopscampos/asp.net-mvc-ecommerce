﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Areas.Admin.Controllers
{
    public class ProductController : BaseController
    {
        public ProductController()
        {
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Produto, Models.Product>();
                cfg.CreateMap<Models.Product, Produto>();
            });
        }
        // GET: Admin/Product
        public ActionResult Index()
        {
            var products = _ctx.Produtos;
            var model = Mapper.Map<IEnumerable<Produto>, IEnumerable<Models.Product>>(products);
            return View(model);
        }

        private Models.Product _getProduct(int id)
        {
            var product = _ctx.Produtos.FirstOrDefault(p => p.Id == id);
            var model = Mapper.Map<Produto, Models.Product>(product);
            return model;
        }

        // GET: Admin/Product/Details/5
        public ActionResult Details(int id)
        {
            return View(_getProduct(id));
        }

        // GET: Admin/Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Product/Create
        [HttpPost]
        public ActionResult Create(Models.Product model)
        {
            try
            {

                // TODO: Add insert logic here
                var product = new Produto
                {
                    PName = model.PName,
                    Brand = model.Brand,
                    Category = model.Category,
                    Description = model.Description,
                    ROL = model.ROL,
                    SID = model.SID,
                    UnitPrice = model.UnitPrice,
                    UnitsInStock = model.UnitsInStock
                };
                _ctx.Produtos.Add(product);
                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                return View(model);
            }
        }

        // GET: Admin/Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_getProduct(id));
        }

        // POST: Admin/Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Models.Product model)
        {
            try
            {
                // TODO: Add update logic here
                Produto p = _ctx.Produtos.FirstOrDefault(pr => pr.Id == model.PID);

                p.UnitPrice = model.UnitPrice;
                p.UnitsInStock = model.UnitsInStock;
                p.SID = model.SID;
                p.Brand = model.Brand;
                p.Description = model.Description;
                p.Category = model.Category;

                _ctx.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                
                return View(model);
            }
        }

        // GET: Admin/Product/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _ctx.Produtos.FirstOrDefault(p => p.Id == id);
            return RedirectToAction("Index");
        }
    }
}
