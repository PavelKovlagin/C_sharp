using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class Driver
    {
        public int id { get; set; } //идентификатор
        public string surname { get; set; } //фамилия
        public string name { get; set; } //имя
        public string patronymic { get; set; } //отчество
        public string login { get; set; } //логин
        public string password { get; set; } //пароль

        public Bus bus { get; set; }
    }
}