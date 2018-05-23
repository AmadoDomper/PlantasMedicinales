using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace PlantasMedicinales.Seguridad.Filters
{
    public class RequiresAuthorizationAttribute : ActionFilterAttribute
    {
        public string CodigoOpcion { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if ((!filterContext.HttpContext.Request.IsAuthenticated) || (HttpContext.Current.Session["Datos"] == null))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Login", action = "LogIn" }));
            else if (HttpContext.Current.Session[CodigoOpcion] == null)
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));


            base.OnActionExecuting(filterContext);
        }
    }
}
