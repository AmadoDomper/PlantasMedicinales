using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PlantasMedicinales.Seguridad.Filters
{
    public class RequiresAuthenticationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Request.IsAjaxRequest())
            {
                if ((!filterContext.HttpContext.Request.IsAuthenticated) || (HttpContext.Current.Session["Datos"] == null))
                {
                    //JavaScriptResult result = new JavaScriptResult()
                    //{
                    //    Script = "window.location='" + "/LogIn/LogIn" + "';"
                    //};
                    //filterContext.Result = result;
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "LogIn", action = "LogIn" }
                    ));

                }
            }
            else
            {
                if (!filterContext.HttpContext.Request.IsAuthenticated || (HttpContext.Current.Session["Datos"] == null))
                {
                    filterContext.Result = new RedirectToRouteResult(
                        new RouteValueDictionary(new { controller = "LogIn", action = "LogIn" }
                    ));
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}
