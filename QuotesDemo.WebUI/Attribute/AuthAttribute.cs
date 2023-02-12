using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace QuotesDemo.WebUI.Attribute
{
    public class AuthAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var myContext = filterContext.HttpContext;
            if (myContext.Session.GetString("UserSession") == null)
            {
                filterContext.Result = new RedirectToRouteResult(new { action = "Index", controller = "Login" });
            }
            else
            {
                base.OnActionExecuting(filterContext);
            }


        }
    }
}
