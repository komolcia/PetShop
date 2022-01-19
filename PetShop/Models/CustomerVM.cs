using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PetShop.Models
{
    public class CustomerVM
    {
        public int CustomerId { get; set; }
        public string Name { get; set; }
     
        public string LastName { get; set; }
        public DateTime? Birthdate { get; set; }
    }
}