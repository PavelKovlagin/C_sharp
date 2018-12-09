using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusCompany.Models;
using System.Data.Entity;

namespace BusCompany.Controllers
{
    public class HomeController : Controller
    {

        BusContext db = new BusContext(); //создаем контекст данных

        public ActionResult Index()
        {
            return View(); //возвращаем представление
        }  
    }
}