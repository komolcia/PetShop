using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Species
    {
        public byte Id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name="Spiecies")]
        public string Name { get; set; }
    }
}