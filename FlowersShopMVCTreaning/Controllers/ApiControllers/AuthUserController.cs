using FlowersShopMVCTraining.Repository.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers.ApiControllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class AuthUserController
    {
        private IUserRepository _userRepository;

        public AuthUserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsLoginAvailable(string login)
        {
            if (login.Length < 3 || login.Length > 20 || login.Length == 0)
            {
                return false;
            }
             return !_userRepository.ExistName(login);
        }
        public bool IsPhoneAvailable(string phone)
        {
            if (!long.TryParse(phone, out _))
            {                
                return false;
            }

            if (phone.Length < 8 || phone.Length > 20 || phone.Length == 0)
            {
                return false;
            }
            return !_userRepository.ExistPhone(phone);
        }
    }
}
