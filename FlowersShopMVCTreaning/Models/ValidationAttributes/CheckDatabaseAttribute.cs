using FlowersShopMVCTraining.Repository.Repository;
using System.ComponentModel.DataAnnotations;

namespace FlowersShopMVCTraining.Models.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class CheckUserDatabaseAttribute : ValidationAttribute
    {
        private readonly string _fieldName;

        public CheckUserDatabaseAttribute(string fieldName)
        {
            _fieldName = fieldName;            
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrEmpty(value.ToString()))
            {
                return ValidationResult.Success;
            }
            
            string fieldValue = value.ToString();
            var userRepository = (UserRepository)validationContext.GetService(typeof(UserRepository));

            var exists = userRepository.FiledValueExists(_fieldName, fieldValue);
            if (exists)
            {
                return new ValidationResult($"Уже существует.");
            }
            return ValidationResult.Success;
        }
    }
}
