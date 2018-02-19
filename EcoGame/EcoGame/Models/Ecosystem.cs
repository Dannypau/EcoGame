using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EcoGame.Models
{
    public class Ecosystem
    {
        [Required]
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string ImgEcosystem { get; set; }

        [Required]
        [MaxLength(50)]
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string DescEcosystem { get; set; }

        [Required]
        [MaxLength(20)]
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string NameEcosystem { get; set; }


        [Required]
        [MaxLength(20)]
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string RegEcosystem { get; set; }


    }
}