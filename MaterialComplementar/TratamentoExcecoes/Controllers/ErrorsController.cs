using System.Web.Mvc;

namespace TratamentoExcecoes.Controllers
{
    public class ErrorsController : Controller
    {
        public ActionResult NotFound()
        {
            return View();
        }

        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult ServiceUnavailable()
        {
            return View();
        }
    }
}