using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Bus
    {
        public int id { get; set; } //идентификатор
        public string marka { get; set; } // марка автобуса
        public string model { get; set; } //модель автобуса
        public int cargo { get; set; } //грузоподъемность
        public int passanger { get; set; } //пассажировместимость
        public int fuel { get; set; } // расход
        public int odometer { get; set; } //пробег
        public bool status { get; set; } //техническое состояние
    }
}