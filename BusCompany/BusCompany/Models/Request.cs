using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Request
    {
        public int requestID { get; set; } //id заявки
        public string client { get; set; } // клиент
        public string adress { get; set; } //адрес
        public int busID { get; set; } //id автобуса
        public DateTime date { get; set; } // дата заявки
    }
}