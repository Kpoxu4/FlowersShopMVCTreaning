using FlowersShopMVCTraining.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FlowersShopMVCTraining.Controllers
{
    public class MainController : Controller
    {
        public IActionResult Index(MainIndexViewModel model)
        {
            return View(model);
        }
    }
}
