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
        public DbSet<Waybill> Waybills { get; set; } 
    }

    public class BusDbInitializer : DropCreateDatabaseAlways<BusContext>
    {
        protected override void Seed(BusContext db)
        {
            db.Buses.Add(new Bus { marka = "PAZ", model = "421", cargo = 4500, passanger = 16, fuel = 22, odometer = 12454, status = true });

            base.Seed(db);
        }
    }
}