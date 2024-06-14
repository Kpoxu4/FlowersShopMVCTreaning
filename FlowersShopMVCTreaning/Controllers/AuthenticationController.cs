using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers
{
    public class AuthenticationController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Registration()
        {
            return View();
        }
    }
}

