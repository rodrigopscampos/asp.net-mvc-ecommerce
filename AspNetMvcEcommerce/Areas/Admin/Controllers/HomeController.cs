using System.Web.Mvc;

namespace AspNetMvcEcommerce.Areas.Admin.Controllers
{
    public class HomeController : BaseController
    {
        // GET: Admin/Index
        public ActionResult Index()
        {
            var model = _ctx.Ordens;

            return View(model);
        }
    }
}