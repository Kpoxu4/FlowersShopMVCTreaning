using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlowersShopMVCTreaning.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
