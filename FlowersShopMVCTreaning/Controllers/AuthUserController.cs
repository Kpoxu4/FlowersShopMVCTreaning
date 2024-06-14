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

        public AuthUserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            var user = _userRepository.GetRegistrationUser(viewModel.UserName, viewModel.Password);
            if (user == null)
            {
                return Redirect("Login");
            }
            LoginUser(user);

            return Redirect("/");
        }
        [HttpGet]
        public IActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Registration(RegistrationViewModel viewModel)// end this
        {
            return View();
        }
        
        public IActionResult Logout()
        {
            HttpContext
                .SignOutAsync()
                .Wait();
            return Redirect("/");
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
