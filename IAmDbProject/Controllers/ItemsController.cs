using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using IAmDbProject.DataContexts;
using IAmDbProject.Models;

namespace IAmDbProject.Controllers
{
    public class ItemsController : Controller
    {
        private IAmDbProjectDb db = new IAmDbProjectDb();

        // GET: Items
        public ActionResult Index()
        {
            var items = db.Items.Include(i => i.Donor).Include(i => i.Event).Include(i => i.Person);
            return View(items.ToList());
        }

        // GET: Items/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // GET: Items/Create
        public ActionResult Create()
        {
            ViewBag.Donor_Id = new SelectList(db.Donors, "Donor_Id", "Name");
            ViewBag.Event_Id = new SelectList(db.Events, "Event_Id", "Address");
            ViewBag.Person_Id = new SelectList(db.People, "Person_Id", "First_Name");
            return View();
        }

        // POST: Items/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Item_Id,Name,Expected_Sale_Value,Description,Start_Price,End_Price,Min_Increment,Buyout_Price,Donor_Id,Event_Id,Person_Id")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Items.Add(item);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Donor_Id = new SelectList(db.Donors, "Donor_Id", "Name", item.Donor_Id);
            ViewBag.Event_Id = new SelectList(db.Events, "Event_Id", "Address", item.Event_Id);
            ViewBag.Person_Id = new SelectList(db.People, "Person_Id", "First_Name", item.Person_Id);
            return View(item);
        }

        // GET: Items/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            ViewBag.Donor_Id = new SelectList(db.Donors, "Donor_Id", "Name", item.Donor_Id);
            ViewBag.Event_Id = new SelectList(db.Events, "Event_Id", "Address", item.Event_Id);
            ViewBag.Person_Id = new SelectList(db.People, "Person_Id", "First_Name", item.Person_Id);
            return View(item);
        }

        // POST: Items/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Item_Id,Name,Expected_Sale_Value,Description,Start_Price,End_Price,Min_Increment,Buyout_Price,Donor_Id,Event_Id,Person_Id")] Item item)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Donor_Id = new SelectList(db.Donors, "Donor_Id", "Name", item.Donor_Id);
            ViewBag.Event_Id = new SelectList(db.Events, "Event_Id", "Address", item.Event_Id);
            ViewBag.Person_Id = new SelectList(db.People, "Person_Id", "First_Name", item.Person_Id);
            return View(item);
        }

        // GET: Items/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item item = db.Items.Find(id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return View(item);
        }

        // POST: Items/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item item = db.Items.Find(id);
            db.Items.Remove(item);
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
