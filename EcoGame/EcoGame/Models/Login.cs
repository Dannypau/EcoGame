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
        public string NameUser { get; set; }
        [Required]
        public string PswUser { get; set; }
    }
}