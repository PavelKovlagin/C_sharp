using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Bus
    {
        public int id { get; set; } //id автобуса
        public string marka { get; set; } // марка автобуса
        public string model { get; set; } //модель автобуса
        public int fuel { get; set; } // расход
    }
}