using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace EcoGame.ViewModels
{
    public class AnimalVM
    {
        [Key]
        public int AnimalId { get; set; }
        public string SoundAnimal { get; set; }
        public string DescAnimal { get; set; }
        public string ImgAnimal { get; set; }
        public string NameAnimal { get; set; }
        public string NameEcosystem { get; set; }
    }
}