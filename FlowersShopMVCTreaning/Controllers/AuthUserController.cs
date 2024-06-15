using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Models.AuthUser;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository;
using FlowersShopMVCTraining.Service;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FlowersShopMVCTraining.Controllers
{
    public class AuthUserController : Controller
    {
        public const string AUTH_METHOD = "Flower";
        private UserRepository _userRepository;
        private AuthStuff _authStuff;
        public AuthUserController(UserRepository userRepository, AuthStuff authStuff)
        {
            _userRepository = userRepository;
            _authStuff = authStuff;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = _userRepository.GetRegistrationUser(viewModel.UserName, viewModel.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Пользователь с таким именем и паролем не найден.");
                return View(viewModel);
            }
            LoginUser(user);

            var model = new MainIndexViewModel
            {
                MessageForUser = $"Добро пожаловать, {user.UserName}"
            };
            
            return RedirectToAction("Index", "Main", model);
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = new User
            {
                UserName = viewModel.UserName,
                Password = viewModel.Password,
                Phone = viewModel.Phone
            };

            _userRepository.Create(user);
            LoginUser(user);

            var model = new MainIndexViewModel
            {
                MessageForUser = $"Вы успешно зарегистрировались, {user.UserName}"
            };

            return RedirectToAction("Index", "Main", model);
        }
        
        public IActionResult Logout()
        {
            HttpContext
                .SignOutAsync()
                .Wait();

            var name = _authStuff.GetUserName();

            var model = new MainIndexViewModel
            {
                MessageForUser = $"Вы успешно вышли, {name}"
            };

            return RedirectToAction("Index", "Main", model);
        }

        private void LoginUser(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(AuthClaimsConstants.ID, user.Id.ToString()),
                new Claim(AuthClaimsConstants.NAME, user.UserName),
                new Claim(AuthClaimsConstants.PHONE, user.Phone),
                new Claim(ClaimTypes.AuthenticationMethod,AUTH_METHOD)
            };

            var identity = new ClaimsIdentity(claims, AUTH_METHOD);

            var principal = new ClaimsPrincipal(identity);

            HttpContext
                .SignInAsync(principal)
                .Wait();
        }

    }
}
