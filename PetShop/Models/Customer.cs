using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Customer
    {
        [Display(Name = "Customer")]
        public int CustomerId { get; set; }
        [Required]
        [Display(Name = "Name Of Customer")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Last Name of Customer")]
        [StringLength(60, ErrorMessage = "First name cannot be longer than 60 characters.")]
        public string LastName { get; set; }


        [Display(Name = "Date of Birth")]
        [Min18Years]
        public DateTime? Birthdate { get; set; }
        public virtual ICollection<Buy> Buys { get; set; }
    }
}