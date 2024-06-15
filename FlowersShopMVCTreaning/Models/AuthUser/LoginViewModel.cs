using System.ComponentModel.DataAnnotations;

namespace FlowersShopMVCTraining.Models.AuthUser
{
    public class LoginViewModel
    {
        private const string REQUIRED_EROR_MESSAGE = "Поле не должно быть пустым.";
        private const string EROR_MESSAGE_PSSWORD = "Пароль должен содержать хотя бы одну цифру, одну заглавную и одну строчную букву.Минимально 8 Символов";

        [Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Имя должно быть от 3 до 20 симоволов")]
        public string UserName { get; set; }

        [Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = EROR_MESSAGE_PSSWORD)]
        [RegularExpression(@"(?=.*\d)(?=.*[a-zA-Zа-яА-Я]).{8,}", ErrorMessage = EROR_MESSAGE_PSSWORD)]
        public string Password { get; set; }
    }
}
