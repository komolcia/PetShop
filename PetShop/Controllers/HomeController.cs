using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace PetShop.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (User.Identity.GetUserName() == "admin@me.com")
            {
                Session["user"] = "Julia";
            }
            else
            {
                String name = User.Identity.GetUserName();

                HttpCookie kt1 = new HttpCookie("user1", name);
                Response.Cookies.Add(kt1);
                kt1.Expires = DateTime.Now.AddSeconds(20);
            }

           
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Charities around the world.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}