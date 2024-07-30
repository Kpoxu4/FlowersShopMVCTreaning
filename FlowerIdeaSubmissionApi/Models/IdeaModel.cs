using System.ComponentModel.DataAnnotations;

namespace FlowerIdeaSubmissionApi.Models
{
    public class IdeaModel
    {
        private const string REQUIRED_EROR_MESSAGE = "Поле не должно быть пустым.";
        private const string EROR_MESSAGE_PHONE = "Номер телефона должен состоять из 10–15 цифр и может начинаться с +.";


        //[Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]
        ////[StringLength(19, MinimumLength = 3, ErrorMessage = "Имя должно быть от 3 до 19 символов включая пробелы")]
        public string AuthorName { get; set; }

        //[Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]
        //[StringLength(15, MinimumLength = 10, ErrorMessage = EROR_MESSAGE_PHONE)]
        //[RegularExpression(@"\+?\d{10,15}", ErrorMessage = EROR_MESSAGE_PHONE)]
        public int AuthorPhone { get; set; }

        //[Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]
        //[StringLength(226, MinimumLength = 20, ErrorMessage = "Текст должен быть от 20 до 226 символов включая пробелы")]
        public string Text { get; set; }    
    }
}
