using FlowersShopMVCTraining.Controllers.ActionFilterAttributes;
using FlowersShopMVCTraining.Models;
using FlowersShopMVCTraining.Models.AuthUser;
using FlowersShopMVCTraining.Repository.Enum;
using FlowersShopMVCTraining.Repository.Model;
using FlowersShopMVCTraining.Repository.Repository;
using FlowersShopMVCTraining.Repository.Repository.Interface;
using FlowersShopMVCTraining.Service;
using FlowersShopMVCTraining.Service.AuthStuff;
using FlowersShopMVCTraining.Service.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace FlowersShopMVCTraining.Controllers
{
    public class AuthUserController : Controller
    {
        public const string AUTH_METHOD = "Flower";
        private IUserRepository _userRepository;
        private IAuthService _authService;
        private IHashingService _hashingService;
        public AuthUserController(IUserRepository userRepository, IAuthService authService, IHashingService hashingService)
        {
            _userRepository = userRepository;
            _authService = authService;
            _hashingService = hashingService;
        }

        [HttpGet]
        [AllowAnonymousOnlyAttribute]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymousOnlyAttribute]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var user = _userRepository.GetRegistrationUser(viewModel.UserName);
            if (user == null)
            {
                ModelState.AddModelError("UserName", "Пользователь с таким именем не найден.");
                return View(viewModel);
            }

            var isPasswordCorrect = _hashingService.VerifyPassword(user.Password, viewModel.Password);

            if (!isPasswordCorrect)
            {
                ModelState.AddModelError("Password", "Пароль не верный.");
                return View(viewModel);
            }

            LoginUser(user!);

            var model = new MainIndexViewModel
            {
                MessageForUser = $"Добро пожаловать, {user!.UserName}"
            };
            
            return RedirectToAction("Index", "Main", model);
        }
        [HttpGet]
        [AllowAnonymousOnlyAttribute]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymousOnlyAttribute]
        public IActionResult Registration(RegistrationViewModel viewModel)
        {
            if (_userRepository.ExistName(viewModel.UserName))
            {
                ModelState.AddModelError(nameof(RegistrationViewModel.UserName), "Имя занято.");
            }
            if (_userRepository.ExistPhone(viewModel.Phone))
            {
                ModelState.AddModelError(nameof(RegistrationViewModel.Phone), "Телефонный номер уже есть");
            }

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
           
            var user = new User
            {
                UserName = viewModel.UserName,
                Password = _hashingService.HashPassword(viewModel.Password),
                Phone = viewModel.Phone,
                UserRole = UserRole.User,
                IsRegistered = true
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

            var name = _authService.GetUserName();

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
                new Claim(AuthClaimsConstants.USER_ROLE, user.UserRole.ToString()),
                new Claim(AuthClaimsConstants.IS_REGISTERED, user.IsRegistered.ToString()),
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
