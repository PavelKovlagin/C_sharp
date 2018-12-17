using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.Models;
using System.Data.Entity;

namespace BusCompany.Controllers.BusController
{
    public class BusController : Controller
    {

        BusContext db = new BusContext(); //создаем контекст данных

        [HttpGet]
        public ActionResult BusesList()
        {
            var buses = db.Buses;
            return View(buses.ToList());
        }

        [HttpGet]
        public ActionResult BusAdd()
        {
            return View();
        }

        [HttpPost]
        public ActionResult BusAdd(Bus bus)
        {
            db.Buses.Add(bus);
            db.SaveChanges();
            return RedirectToAction("BusesList");
        }

        [HttpGet]
        public ActionResult BusEdit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            Bus bus = db.Buses.Find(id);
            if (bus != null)
            {
                return View(bus);
            }
            return HttpNotFound();
        }

        [HttpPost]
        public ActionResult BusEdit(Bus bus)
        {
            db.Entry(bus).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("BusesList");
        }

        [HttpGet]
        public ActionResult BusDelete(int id)
        {
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            return View(bus);
        }

        [HttpPost, ActionName("BusDelete")]
        public ActionResult BusDeleteConfirmed(int id)
        {
            Bus bus = db.Buses.Find(id);
            if (bus == null)
            {
                return HttpNotFound();
            }
            db.Buses.Remove(bus);
            db.SaveChanges();
            return RedirectToAction("BusesList");
        }
    }
}