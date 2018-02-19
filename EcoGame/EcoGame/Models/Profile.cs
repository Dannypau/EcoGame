using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EcoGame.Models
{
    public class Profile
    {
        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string NameProfile { get; set; }
    }
}