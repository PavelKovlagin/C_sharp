using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BusCompany.Models
{
    public class EditModel
    {
        public string surname { get; set; } //фамилия
        public string name { get; set; } //имя
        public string patronymic { get; set; } //отчество
        public string email { get; set; } //email
        public string role { get; set; } //роль
    }
}