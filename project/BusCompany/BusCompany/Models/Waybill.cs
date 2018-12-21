using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Waybill
    {
        public int id { get; set; } //идентификатор
        public DateTime date { get; set; } //дата оформления
        public int? busID { get; set; }
        public Bus bus { get; set; }
        public string client { get; set; }
        public string logist { get; set; }
        public string path { get; set; } //маршрут
        public DateTime departureDate { get; set; } //дата выезда
        public DateTime returnDate { get; set; } //дата возвращения
    }
}