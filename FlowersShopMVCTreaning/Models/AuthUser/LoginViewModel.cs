using System.ComponentModel.DataAnnotations;

namespace FlowersShopMVCTraining.Models.AuthUser
{
    public class LoginViewModel
    {
        private const string REQUIRED_EROR_MESSAGE = "���� �� ������ ���� ������.";
        private const string EROR_MESSAGE_PSSWORD = "������ ������ ��������� ���� �� ���� �����, ���� ��������� � ���� �������� �����.���������� 8 ��������";

        [Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "��� ������ ���� �� 3 �� 20 ���������")]
        public string UserName { get; set; }

        [Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = EROR_MESSAGE_PSSWORD)]
        [RegularExpression(@"(?=.*\d)(?=.*[a-zA-Z�-��-�]).{8,}", ErrorMessage = EROR_MESSAGE_PSSWORD)]
        public string Password { get; set; }
    }
}
