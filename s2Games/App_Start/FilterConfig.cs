using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace s2Games
{
    public class FilterConfig : ActionFilterAttribute
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.Session.Contents["user"] == null &&
        filterContext.HttpContext.Request.RequestContext.RouteData.GetRequiredString("controller") != "Login")
            {
                RouteValueDictionary redirectTargetDictionary = new RouteValueDictionary();
                redirectTargetDictionary.Add("action", "Index");
                redirectTargetDictionary.Add("controller", "Login");

                filterContext.Result = new RedirectToRouteResult(redirectTargetDictionary);
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
