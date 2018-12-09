using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.Models;
using System.Data.Entity;

namespace BusCompany.Controllers.DriverController
{
    public class DriverController : Controller
    {

        BusContext db = new BusContext(); //создаем контекст данных

        [HttpGet]
        public ActionResult DriversList()
        {
            var drivers = db.Drivers.Include(p => p.bus);
            return View(drivers.ToList());
        }
    }
}