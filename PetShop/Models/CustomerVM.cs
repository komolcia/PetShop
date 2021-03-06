using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required]
        [StringLength(60, ErrorMessage = "First name cannot be longer than 60 characters.")]
        public string LastName { get; set; }


        [Display(Name = "Date of Birth")]
        [Min18Years]
        public DateTime? Birthdate { get; set; }
    }
}