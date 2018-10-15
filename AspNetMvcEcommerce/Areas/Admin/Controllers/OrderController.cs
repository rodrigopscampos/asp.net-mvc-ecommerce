using AutoMapper;
using AspNetMvcEcommerce.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Areas.Admin.Controllers
{
    public class OrderController : BaseController
    {
        static OrderController()
        {
            try
            {
                Mapper.Initialize(cfg => {
                    cfg.CreateMap<Ordem, OrderModel>();
                });
            }
            catch (System.Exception)
            {
            }
        }

        public OrderController()
        {
           
        }

        // GET: Admin/Order
        public ActionResult Index()
        {
            var orders = _ctx.Ordens;
            var model = Mapper.Map<IEnumerable<Ordem>, IEnumerable<OrderModel>>(orders);
            return View(model);
        }

        // GET: Admin/Order/Details/5
        public ActionResult Details(int id)
        {
            var order = _ctx.Ordens.FirstOrDefault(o => o.ItensId == id);
            var model = Mapper.Map<OrderModel>(order);
            return View(model);
        }
    }
}
