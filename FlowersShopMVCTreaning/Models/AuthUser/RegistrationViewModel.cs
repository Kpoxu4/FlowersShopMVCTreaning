using System.ComponentModel.DataAnnotations;

namespace FlowersShopMVCTraining.Models.AuthUser
{
    public class RegistrationViewModel
    {
      
        public string UserName { get; set; }

        public string Password { get; set; }
        public string RepeatPassword { get; set; }

        public string Phone { get; set; }
    }
}
