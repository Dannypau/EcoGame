using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EcoGame.Models
{
    public class ExcludeSpecialCharacters: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {


            //Validamos la cadena que no contenga caracteres especiales

            if (Convert.ToString(value).Contains("@") || Convert.ToString(value).Contains("!") || Convert.ToString(value).Contains("\""))
            {
                var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(errorMessage);
            }
            return ValidationResult.Success;
        }
    }
}