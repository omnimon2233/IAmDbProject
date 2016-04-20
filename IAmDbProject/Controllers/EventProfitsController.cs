using IAmDbProject.DataContexts;
using IAmDbProject.Models;
using IAmDbProject.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace IAmDbProject.Controllers
{
    public class EventProfitsController : Controller
    {
        private IAmDbProjectDb db = new IAmDbProjectDb();

        // GET: Report
        public ActionResult Index()
        {
            
            var events = db.Events.ToList();
            var items = db.Items.ToList();
            List<Event_Profit> eventProfits = new List<Event_Profit>();

            foreach (Event event_ in events)
            {
                double total = 0;
                double expected = 0;
                Event_Profit ev = new Event_Profit();

                ev.EventId = event_.Event_Id;

                foreach (Item item in items)
                {
                    total = total + item.Buyout_Price;
                    expected = expected + item.Expected_Sale_Value;
                }

                ev.Event_Total = total;
                ev.Event_Expected = expected;
                ev.Event_Difference = expected - total;

                eventProfits.Add(ev);
            }

            try
            {
                return View(eventProfits);
            }
            catch (Exception e)
            {

                return HttpNotFound(e.Message);
            }
        }

        // GET: Report/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var events = db.Events.Find(id);
            if (events == null)
            {
                return HttpNotFound();
            }
            return View(events);
        }
        
    }
}