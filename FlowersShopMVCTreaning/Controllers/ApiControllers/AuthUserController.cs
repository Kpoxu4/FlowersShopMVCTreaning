using FlowersShopMVCTraining.Repository.Repository;
using Microsoft.AspNetCore.Mvc;

namespace FlowersShopMVCTraining.Controllers.ApiControllers
{
    [ApiController]
    [Route("/api/[controller]/[action]")]
    public class AuthUserController
    {
        private UserRepository _userRepository;

        public AuthUserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool IsLoginAvailable(string login)
        {
             return !_userRepository.ExistName(login);
        }
     
    }
}
