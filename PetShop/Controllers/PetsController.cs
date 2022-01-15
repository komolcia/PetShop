using PetShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    public class PetsController : Controller
    {
        // GET: Pets
        public ActionResult Random()
        {
            var pet=new Pet() { Name="Shrek!"};
            return View(pet);
        }
    }
}