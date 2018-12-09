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
        public int idBus { get; set; } //автобус
        public int idDriver { get; set; } //водитель
        public string path { get; set; } //маршрут
        public DateTime departureDate { get; set; } //дата выезда
        public DateTime returnDate { get; set; } //дата возвращения
    }
}