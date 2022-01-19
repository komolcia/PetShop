using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class HasToBeToday: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var buy = (Buy)validationContext.ObjectInstance;

            if (buy.DateBuied == null)
                return new ValidationResult("Date is required.");

          

            return (DateTime.Today == buy.DateBuied)
                ? ValidationResult.Success
                : new ValidationResult("It has to be today!");
        }
    }
}
