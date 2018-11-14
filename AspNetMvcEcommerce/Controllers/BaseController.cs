using AspNetMvcEcommerce.Models;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class BaseController : Controller
    {
        protected AspNetMvcEcommerceContext _ctx = new AspNetMvcEcommerceContext();

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
        }
    }
}