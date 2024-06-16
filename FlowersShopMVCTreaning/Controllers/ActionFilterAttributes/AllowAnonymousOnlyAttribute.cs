using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers.ActionFilterAttributes
{
    public class AllowAnonymousOnlyAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        { "controller", "Main" },
                        { "action", "Index" }
                    });
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
