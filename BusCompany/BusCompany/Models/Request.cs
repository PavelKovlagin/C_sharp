using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Request
    {
        public int id { get; set; } //идентификатор
        public int idClient { get; set; } //клиент
        public int idBus { get; set; } //автобус
        public DateTime date { get; set; } // дата оформления заявки
        public string path { get; set; } //маршрут       
        public DateTime departureDate { get; set; } //дата выезда
        public DateTime returnDate { get; set; } // дата возвращения


    }
}