using FlowersShopMVCTraining.Controllers.ActionFilterAttributes;
using FlowersShopMVCTraining.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers
{
    [Authorize]
    [IsAdmin]
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(CreatingShopCardViewModel model)// обработка даных сохранениие в базе
        {
            

            

            return View(model);
        }
    }

}
