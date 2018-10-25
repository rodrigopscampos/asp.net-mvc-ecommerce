using System.Web.Mvc;

namespace AspNetMvcEcommerce.Areas.Admin.Controllers
{   
    [RoutePrefix("")]
    public class HomeController : BaseController
    {
        [Route("")]
        public ActionResult Index()
        {
            var model = _ctx.Ordens;

            return View(model);
        }
    }
}