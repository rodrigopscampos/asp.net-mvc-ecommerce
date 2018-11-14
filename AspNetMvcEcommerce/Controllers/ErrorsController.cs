using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AspNetMvcEcommerce.Controllers
{
    public class ErrorsController : Controller
    {
        // GET: Errors
        public ActionResult InternalServerError()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}