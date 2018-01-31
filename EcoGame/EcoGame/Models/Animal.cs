using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EcoGame.Models
{
    public class Animal
    {

        [Required]
        [MaxLength(2)]
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string SoundAnimal { get; set; }

        [Required]
        [MaxLength(2)]
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string AnimalName { get; set; }





    }
}