﻿using FlowersShopMVCTraining.Models.ValidationAttributes;
using FlowersShopMVCTraining.Repository.Repository;
using Microsoft.Extensions.FileSystemGlobbing.Internal;
using System.ComponentModel.DataAnnotations;

namespace FlowersShopMVCTraining.Models.AuthUser
{
    public class RegistrationViewModel //TODO add Attribute
    {
        private const string REQUIRED_EROR_MESSAGE = "Поле не должно быть пустым.";
        private const string EROR_MESSAGE_PHONE = "Номер телефона должен состоять из 10–15 цифр и может начинаться с +.";
        private const string EROR_MESSAGE_PSSWORD = "Пароль должен содержать хотя бы одну цифру, одну заглавную и одну строчную букву.";

        [Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]
        [CheckUserDatabaseAttribute("UserName")]
        public string UserName { get; set; }

        [Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]
        [StringLength(20, MinimumLength = 8, ErrorMessage = EROR_MESSAGE_PSSWORD)]
        [RegularExpression(@"(?=.*\d)(?=.*[a-zA-Zа-яА-Я]).{8,}", ErrorMessage = EROR_MESSAGE_PSSWORD)]
        public string Password { get; set; }

        [Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
        public string RepeatPassword { get; set; }

        [Required(ErrorMessage = REQUIRED_EROR_MESSAGE)]       
        [StringLength(15, MinimumLength = 10, ErrorMessage = EROR_MESSAGE_PHONE)]
        [RegularExpression(@"\+?\d{10,15}", ErrorMessage = EROR_MESSAGE_PHONE)]
        [CheckUserDatabaseAttribute("Phone")]
        public string Phone { get; set; }
    }
}

