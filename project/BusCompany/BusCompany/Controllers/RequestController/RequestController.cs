using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.Models;
using System.Data.Entity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace BusCompany.Controllers.RequestController
{
    public class RequestController : Controller
    {
        BusContext db = new BusContext(); //создаем контекст данных

        private ApplicationUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
        }

        [Authorize(Roles = "director, logist")]
        public ActionResult RequestsList()
        {
            var requests = db.Requests.Include(p => p.bus);
            return View(requests.ToList());
        }

        [Authorize(Roles = "client")]
        [HttpGet]
        public ActionResult RequestAdd(int ID)
        {
            ApplicationUser user = UserManager.FindByEmail(User.Identity.Name);
            if (user != null)
            {
                Bus busID = db.Buses.Find(ID);
                Request req = new Request();         
                ViewBag.Buses = busID;
                ViewBag.User = user;
                return View();
            };
            return RedirectToAction("Login", "Account");
        }

        [HttpPost]
        public ActionResult RequestAdd(Request model)
        {
            Request reqest = new Request
            {
                client = model.client,
                busID = model.busID,
                date = DateTime.Now,
                path = model.path,
                departureDate = model.departureDate,
                returnDate = model.returnDate,
            };
            db.Requests.Add(reqest);
            db.SaveChanges();

            return RedirectToAction("BusesList", "Bus");
        }

        [Authorize (Roles ="director, logist")]
        [HttpGet]
        public ActionResult RequestDelete(int id)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            Bus bus = db.Buses.Find(request.busID);
            ViewBag.Bus = bus;
            return View(request);
        }

        [HttpPost, ActionName("RequestDelete")]
        public ActionResult RequestDeleteConfirmed(int id)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
            db.Requests.Remove(request);
            db.SaveChanges();
            return RedirectToAction("RequestsList");
        }
    }
}