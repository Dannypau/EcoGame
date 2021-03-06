﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace EcoGame.Models
{
    public class User
    {
        [Required]
        [MinLength(4)]
        [MaxLength(15)]
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string NameUser { get; set; }


        [Required]
        [MinLength(6)]
        [MaxLength(10)]
        [ExcludeSpecialCharacters(ErrorMessage = "No se acepta caracteres especiales")]
        public string PswUser { get; set; }
    }
}