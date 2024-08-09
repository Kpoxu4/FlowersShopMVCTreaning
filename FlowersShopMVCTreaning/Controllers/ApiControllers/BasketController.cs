using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTraining.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers.ApiControllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class BasketController : ControllerBase
    {
        private IAuthService _authService;
        private IUserRepository _userRepository;

        public BasketController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost]
        public IActionResult CreateBasketItemWithRegisteredUser(int cardId)
        {
            
            if (!_authService.IsAuthenticated())
            {
                return StatusCode(300);
            }
            // сделать таблицу в базе данных и потом и отправлять число айтемов каторый заказал пользователь
            return Ok();
        }
        [HttpPost]
        public IActionResult CreateBasketItem(string name, string phone)
        {
            //проверяем если такой номер телефона если есть то юзера не создаем а привязуем корзину  к этому номера теелфона?
            var user = new User
            {
                UserName = name,
                UserRole = UserRole.User,
                Phone = phone,
                IsRegistered = false,
                Password = null
            };
            
            // сделать таблицу в базе данных и потом и отправлять число айтемов каторый заказал пользователь
            return Ok();
        }
    }
}
