using System.Web.Mvc;

namespace AspNetMvcEcommerce.Areas.Admin.Controllers
{
    [Authorize(Roles = "admin")]
    public class BaseController : Controller
    {
        protected AspNetMvcEcommerceContext _ctx = new AspNetMvcEcommerceContext();

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _ctx.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}