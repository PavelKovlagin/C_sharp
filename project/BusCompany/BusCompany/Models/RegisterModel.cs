using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace BusCompany.Models
{
    public class RegisterModel
    {
        [Required]
        public string surname { get; set; } //фамилия
        [Required]
        public string name { get; set; } //имя
        [Required]
        public string patronymic { get; set; } //отчество

        [Required]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}