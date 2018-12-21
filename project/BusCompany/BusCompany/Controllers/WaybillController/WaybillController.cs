using BusCompany.Models;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
namespace BusCompany.Controllers
{
    public class WaybillController : Controller
    {

        BusContext db = new BusContext(); //создаем контекст данных

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [Authorize (Roles = "director, logist, driver")]
        [HttpGet]
        public ActionResult WaybillsList()
        {
            var waybils = db.Waybills.Include(p => p.bus);
            return View(waybils.ToList());
        }

        [Authorize (Roles = "logist")]
        [HttpGet]
        public ActionResult WaybillAdd(int ID)
        {
            Request req = db.Requests.Find(ID);
            Bus bus = db.Buses.Find(req.busID);
            ViewBag.Request = req;
            ViewBag.Bus = bus;
            return View();
        }

        [HttpPost]
        public ActionResult WaybillAdd(Waybill model)
        {
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            Waybill waybill = new Waybill
            {
                date = DateTime.Now,
                busID = model.busID,
                client = model.client,
                logist = user.Email,
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