using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PetShop.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Mvc;

namespace PetShop.Controllers
{
    [Authorize(Roles ="Admin")]
    public class RoleController : Controller
    {
        ApplicationDbContext context;

        public RoleController()
        {
            context = new ApplicationDbContext();
        }

        // GET: Role
        public ActionResult Index()
        {
            var Roles = context.Roles.ToList();
            return View(Roles);
        }


        public ActionResult Create()
        {
            var Role = new IdentityRole();
            return View(Role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole Role)
        {
            context.Roles.Add(Role);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}