using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EcoGame.Models
{
    public class Login
    {
       

        [Required]
        [MinLength(5)]
        [MaxLength(10)]
        public string NameUser { get; set; }
        [Required]
        [MinLength(7)]
        [MaxLength(12)]
        public string PswUser { get; set; }
    }
}