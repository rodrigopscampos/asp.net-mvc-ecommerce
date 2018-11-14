using System.Web.Mvc;

namespace TratamentoExcecoes
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new CustomHandleErrorAttribute());
        }
    }

    public class CustomHandleErrorAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            /*
            if (!filterContext.ExceptionHandled)
            {
                string controllerName = (string)filterContext.RouteData.Values["controller"];
                string actionName = (string)filterContext.RouteData.Values["action"];

                var custException = new Exception("There is some error");

                //podemos logar
                Console.WriteLine(filterContext.Exception.Message + " in " + controllerName);

                var model = new HandleErrorInfo(custException, controllerName, actionName);

                filterContext.Result = new ViewResult
                {
                    ViewName = "~/Views/Errors/InternalServerError.cshtml",
                    ViewData = new ViewDataDictionary<HandleErrorInfo>(model),
                    TempData = filterContext.Controller.TempData
                };

                filterContext.ExceptionHandled = true;
            }
            
            */

            base.OnException(filterContext);
        }
    }
}
