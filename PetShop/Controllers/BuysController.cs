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
    public class BuysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Buys
        public ActionResult Index()
        {
            var buys = db.Buys.Include(b => b.Customer).Include(b => b.Pet);
            return View(buys.ToList());
        }

        // GET: Buys/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buy buy = db.Buys.Find(id);
            if (buy == null)
            {
                return HttpNotFound();
            }
            return View(buy);
        }

        // GET: Buys/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name");
            ViewBag.Id = new SelectList(db.Pets, "PetId", "Name");
            return View();
        }

        // POST: Buys/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CustomerId,DateBuied")] Buy buy)
        {
            if (ModelState.IsValid)
            {
                db.Buys.Add(buy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", buy.CustomerId);
            ViewBag.Id = new SelectList(db.Pets, "PetId", "Name", buy.Id);
            return View(buy);
        }

        // GET: Buys/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buy buy = db.Buys.Find(id);

            if (buy == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", buy.CustomerId);
            ViewBag.Id = new SelectList(db.Pets, "PetId", "Name", buy.Id);
            return View(buy);
        }

        // POST: Buys/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CustomerId,DateBuied")] Buy buy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(buy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "Name", buy.CustomerId);
            ViewBag.Id = new SelectList(db.Pets, "PetId", "Name", buy.Id);
            return View(buy);
        }

        // GET: Buys/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Buy buy = db.Buys.Find(id);
            if (buy == null)
            {
                return HttpNotFound();
            }
            return View(buy);
        }

        // POST: Buys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Buy buy = db.Buys.Find(id);
            db.Buys.Remove(buy);
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
