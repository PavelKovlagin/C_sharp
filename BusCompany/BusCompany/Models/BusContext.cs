using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BusCompany.Models
{
    public class BusContext : DbContext
    {
        public DbSet<Bus> Buses { get; set; }
        public DbSet<Request> Requests { get; set; }
    }
}