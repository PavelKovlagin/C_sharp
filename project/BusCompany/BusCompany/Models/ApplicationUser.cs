using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BusCompany.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string surname { get; set; } //фамилия
        public string name { get; set; } //имя
        public string patronymic { get; set; } //отчество

        public ICollection<Request> requests { get; set; }
        public ApplicationUser()
        {
            requests = new List<Request>();
        }
    }
}