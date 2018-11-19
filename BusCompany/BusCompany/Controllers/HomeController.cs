using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.Models;

namespace BusCompany.Controllers
{
    public class HomeController : Controller
    {

        BusContext db = new BusContext(); //создаем контекст данных

        public ActionResult Index()
        {
            IEnumerable<Bus> buses = db.Buses; //получаем из БД все объекты Bus
            ViewBag.Buses = buses; //передаем все объекты в динамическое свойство buses в ViewBag
            return View(); //возвращаем представление
        }

        [HttpGet]
        public ActionResult Request (int id)
        {
            ViewBag.BusId = id;
            return View();
        }

        [HttpPost]
        public string Request(Request request)
        {
            request.Date = DateTime.Now; //добавление информации о заявке в базу данных
            db.Requests.Add(request);
            db.SaveChanges();
            return "Спасибо, " + request.client + ", за заявку";
        }
    }
}