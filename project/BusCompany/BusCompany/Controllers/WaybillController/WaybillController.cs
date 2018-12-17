using BusCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BusCompany.Controllers
{
    public class WaybillController : Controller
    {

        BusContext db = new BusContext(); //создаем контекст данных

        [HttpGet]
        public ActionResult WaybillsList()
        {
            var waybils = db.Waybills;
            return View(waybils.ToList());
        }

        [HttpGet]
        public ActionResult WaybillAdd(int ID)
        {
            Request req = db.Requests.Find(ID);
            ViewBag.Request = req;
            return View();
        }

        [HttpPost]
        public ActionResult WaybillAdd(Waybill model)
        {
            Waybill waybill = new Waybill
            {
                date = DateTime.Now,
                path = model.path,
                departureDate = model.departureDate,
                returnDate = model.returnDate
            };
            db.Waybills.Add(waybill);
            db.SaveChanges();

            return RedirectToAction("WaybillsList", "Waybill");
        }
    }
}