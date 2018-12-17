using System.Web.Mvc;
using BusCompany.Models;

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