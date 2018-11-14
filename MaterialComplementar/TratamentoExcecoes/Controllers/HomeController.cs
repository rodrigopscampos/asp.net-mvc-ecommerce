using System.Web.Mvc;

namespace TratamentoExcecoes.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Exception()
        {
            //não há uma view Exception
            return View();
        }
    }
}