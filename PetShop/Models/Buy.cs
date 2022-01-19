using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class Buy
    {
        [ForeignKey("Pet")]
        [CheckIfBought]
        public int Id { get; set; }
        
       


        public virtual Pet Pet { get; set; }

        public int CustomerId { get; set; }

        public virtual Customer Customer { get; set; }



        [Required]
        [HasToBeToday]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DateBuied { get; set; }
        
    }
}