using FlowersShopMVCTraining.Service.AuthStuff;
using FlowersShopMVCTraining.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FlowersShopMVCTraining.Controllers.ActionFilterAttributes
{
    public class IsAdminAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var authService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();
            if (!authService.IsAdmin())
            {
                context.Result = new ForbidResult();
                return;
            }

            base.OnActionExecuting(context);
        }
    }
}
