using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class CheckIfBought : ValidationAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var buy = (Buy)validationContext.ObjectInstance;

            Buy buy1 = db.Buys.Find(buy.Id);

            return (buy1 ==null)
               ? ValidationResult.Success
               : new ValidationResult("Animal was bought.");


        }
    }
}