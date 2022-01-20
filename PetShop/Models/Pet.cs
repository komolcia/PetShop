using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Pet
    {
        [Display(Name = "Pet")]
        public int PetId { get; set; }
        [Required]
        [Display(Name = "Name Of Pet")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        public Species Species { get; set; }

        [Display(Name = "Species")]
        [Required]
        public byte SpeciesId { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
    
        public virtual Buy Buy { get; set; }
    }
}