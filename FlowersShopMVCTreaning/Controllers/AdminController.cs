using FlowersShopMVCTraining.Controllers.ActionFilterAttributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers
{
    [Authorize]
    [IsAdmin]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
