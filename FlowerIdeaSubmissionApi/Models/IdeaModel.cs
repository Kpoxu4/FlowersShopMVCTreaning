using System.ComponentModel.DataAnnotations;

namespace FlowerIdeaSubmissionApi.Models
{
    public class IdeaModel
    {
                   
        [Required(ErrorMessage = "Поле Имя не должно быть пустым")]
        [StringLength(19, MinimumLength = 3, ErrorMessage = "Имя должно быть от 3 до 19 символов включая пробелы")]
        public string AuthorName { get; set; }
                
        [Required(ErrorMessage = "Поле Телефон не должно быть пустым")]
        [StringLength(15, MinimumLength = 10, ErrorMessage = "Номер телефона должен состоять из 10–15 цифр и может начинаться с +.")]
        //[RegularExpression(@"\+?\d{10,15}", ErrorMessage = EROR_MESSAGE_PHONE)]
        public string AuthorPhone { get; set; }
       
        [Required(ErrorMessage = "Поле Текст не должно быть пустым")]
        [StringLength(226, MinimumLength = 20, ErrorMessage = "Текст должен быть от 20 до 226 символов включая пробелы")]
        public string Text { get; set; }
    }
}
