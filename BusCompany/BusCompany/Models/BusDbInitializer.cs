using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BusCompany.Models
{
    public class BusDbInitializer : DropCreateDatabaseAlways<BusContext>
    {
        protected override void Seed(BusContext db)
        {
            db.Buses.Add(new Bus { marka = "PAZ", model = "421", fuel = 22 });
            db.Buses.Add(new Bus { marka = "UAZ", model = "333", fuel = 21 });
            db.Buses.Add(new Bus { marka = "GAZ", model = "546", fuel = 23 });

            base.Seed(db);
        }
    }
}