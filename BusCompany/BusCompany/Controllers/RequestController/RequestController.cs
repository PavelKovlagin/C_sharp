using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.Models;
using System.Data.Entity;

namespace BusCompany.Controllers.RequestController
{
    public class RequestController : Controller
    {

        BusContext db = new BusContext(); //создаем контекст данных

        public ActionResult RequestsList()
        {
            IEnumerable<Request> requests = db.Requests; //получаем из БД все объекты Request
            ViewBag.Requests = requests; //передаем все объекты в динамическое свойство requests в ViewBag
            return View(); //возвращаем представление
        }

        [HttpGet]
        public ActionResult RequestAdd(int id)
        {
            ViewBag.BusId = id;
            return View();
        }

        [HttpPost]
        public ActionResult RequestAdd(Request request)
        {
            request.date = DateTime.Now; //добавление информации о заявке в базу данных
            db.Requests.Add(request);
            db.SaveChanges();
            return RedirectToAction("Buses");
        }

        [HttpGet]
        public ActionResult RequestDelete(int id)
        {
            Request request = db.Requests.Find(id);
            if (request == null)
            {
                return HttpNotFound();
            }
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