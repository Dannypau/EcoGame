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
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string SoundAnimal { get; set; }

        [Required]
        [MaxLength(15)]
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string AnimalName { get; set; }

        [Required]
        [MaxLength(25)]
        public string DescAnimal { get; set; }




    }
}