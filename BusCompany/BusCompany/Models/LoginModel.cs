using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusCompany.Models
{
    public class LoginModel 
    {
        public string surname { get; set; } //фамилия
        public string name { get; set; } //имя
        public string patronymic { get; set; } //отчество
        [Required]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}