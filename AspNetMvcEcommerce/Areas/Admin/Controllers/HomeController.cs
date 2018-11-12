using System.Web.Mvc;
using System.Linq;

namespace AspNetMvcEcommerce.Areas.Admin.Controllers
{   
    [RoutePrefix("")]
    public class HomeController : BaseController
    {
        [Route("")]
        public ActionResult Index()
        {
            var model = _ctx.Ordens.ToArray();

            return View(model);
        }
    }
}