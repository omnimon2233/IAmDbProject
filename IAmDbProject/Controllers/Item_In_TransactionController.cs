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
    public class Item_In_TransactionController : Controller
    {
        private IAmDbProjectDb db = new IAmDbProjectDb();

        // GET: Item_In_Transaction
        public ActionResult Index()
        {
            var itemsInTransactions = db.ItemsInTransactions.Include(i => i.Item).Include(i => i.Transaction);
            return View(itemsInTransactions.ToList());
        }

        // GET: Item_In_Transaction/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_In_Transaction item_In_Transaction = db.ItemsInTransactions.Find(id);
            if (item_In_Transaction == null)
            {
                return HttpNotFound();
            }
            return View(item_In_Transaction);
        }

        // GET: Item_In_Transaction/Create
        public ActionResult Create()
        {
            ViewBag.Item_Id = new SelectList(db.Items, "Item_Id", "Name");
            ViewBag.Transaction_Id = new SelectList(db.Transaction, "Transaction_Id", "Zip");
            return View();
        }

        // POST: Item_In_Transaction/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Transaction_Id,Item_Id")] Item_In_Transaction item_In_Transaction)
        {
            if (ModelState.IsValid)
            {
                db.ItemsInTransactions.Add(item_In_Transaction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Item_Id = new SelectList(db.Items, "Item_Id", "Name", item_In_Transaction.Item_Id);
            ViewBag.Transaction_Id = new SelectList(db.Transaction, "Transaction_Id", "Zip", item_In_Transaction.Transaction_Id);
            return View(item_In_Transaction);
        }

        // GET: Item_In_Transaction/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_In_Transaction item_In_Transaction = db.ItemsInTransactions.Find(id);
            if (item_In_Transaction == null)
            {
                return HttpNotFound();
            }
            ViewBag.Item_Id = new SelectList(db.Items, "Item_Id", "Name", item_In_Transaction.Item_Id);
            ViewBag.Transaction_Id = new SelectList(db.Transaction, "Transaction_Id", "Zip", item_In_Transaction.Transaction_Id);
            return View(item_In_Transaction);
        }

        // POST: Item_In_Transaction/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Transaction_Id,Item_Id")] Item_In_Transaction item_In_Transaction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(item_In_Transaction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Item_Id = new SelectList(db.Items, "Item_Id", "Name", item_In_Transaction.Item_Id);
            ViewBag.Transaction_Id = new SelectList(db.Transaction, "Transaction_Id", "Zip", item_In_Transaction.Transaction_Id);
            return View(item_In_Transaction);
        }

        // GET: Item_In_Transaction/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Item_In_Transaction item_In_Transaction = db.ItemsInTransactions.Find(id);
            if (item_In_Transaction == null)
            {
                return HttpNotFound();
            }
            return View(item_In_Transaction);
        }

        // POST: Item_In_Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Item_In_Transaction item_In_Transaction = db.ItemsInTransactions.Find(id);
            db.ItemsInTransactions.Remove(item_In_Transaction);
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
