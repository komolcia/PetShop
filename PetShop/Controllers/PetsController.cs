using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PetShop.Models;

namespace PetShop.Controllers
{
    [Authorize]
    public class PetsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Pets
        public ActionResult Index()
        {
            var pets = db.Pets.Include(p => p.Buy).Include(p => p.Species);
            return View(pets.ToList());
        }
        [ChildActionOnly]
        public ActionResult ListPet()
        {
            var pets = db.Pets.Select(cus => new PetVM { Name = cus.Name, Species=cus.Species,DateOfBirth=cus.DateOfBirth, PetId = cus.PetId,SpeciesId=cus.SpeciesId ,Buy=cus.Buy}).ToList();
            return PartialView("_ListPets", pets);
        }

        // GET: Pets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // GET: Pets/Create
        [Authorize(Roles ="Admin")]
        public ActionResult Create()
        {
            ViewBag.PetId = new SelectList(db.Buys, "Id", "Id");
            ViewBag.SpeciesId = new SelectList(db.Species, "Id", "Name");
            return View();
        }

        // POST: Pets/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PetId,Name,SpeciesId,DateOfBirth")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Pets.Add(pet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PetId = new SelectList(db.Buys, "Id", "Id", pet.PetId);
            ViewBag.SpeciesId = new SelectList(db.Species, "Id", "Name", pet.SpeciesId);
            return View(pet);
        }

        // GET: Pets/Edit/5
        [Authorize(Roles ="Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            ViewBag.PetId = new SelectList(db.Buys, "Id", "Id", pet.PetId);
            ViewBag.SpeciesId = new SelectList(db.Species, "Id", "Name", pet.SpeciesId);
            return View(pet);
        }

        // POST: Pets/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PetId,Name,SpeciesId,DateOfBirth")] Pet pet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PetId = new SelectList(db.Buys, "Id", "Id", pet.PetId);
            ViewBag.SpeciesId = new SelectList(db.Species, "Id", "Name", pet.SpeciesId);
            return View(pet);
        }

        // GET: Pets/Delete/5
        [Authorize(Roles ="Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Pet pet = db.Pets.Find(id);
            if (pet == null)
            {
                return HttpNotFound();
            }
            return View(pet);
        }

        // POST: Pets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pet pet = db.Pets.Find(id);
            Buy buy = db.Buys.Find(id);
            if(buy!=null)
            {
                return RedirectToAction("Index");
            }
            db.Pets.Remove(pet);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
