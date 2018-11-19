using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Request
    {
        public int requestId { get; set; } //id заявки
        public string client { get; set; } // клиент
        public int busID { get; set; } //id автобуса
        public DateTime Date { get; set; } // дата заявки
    }
}