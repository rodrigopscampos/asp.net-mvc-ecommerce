using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Areas.Admin.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(){
            Mapper.Initialize(cfg => {
                cfg.CreateMap<Cliente, AspNetMvcEcommerce.Models.Cliente>();
            });
        }

        // GET: Admin/Customer
        public ActionResult Index()
        {
            var customers = _ctx.Clientes.ToList();
            var model = Mapper.Map<IEnumerable<Cliente>, IEnumerable<AspNetMvcEcommerce.Models.Cliente>>(customers);
            return View("Index", model);
        }

        // GET: Admin/Customer/Details/5
        public ActionResult Details(int id)
        {
            var customer = _ctx.Clientes.FirstOrDefault(c => c.Id == id);
            var model = Mapper.Map<Cliente, AspNetMvcEcommerce.Models.Cliente>(customer);
            return View(model);
        }

        // GET: Admin/Customer/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _ctx.Clientes.FirstOrDefault(c => c.Id == id);
            _ctx.Clientes.Remove(customer);
            _ctx.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
