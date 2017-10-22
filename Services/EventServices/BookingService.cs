using Domain.entities;
using ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using We.Data.Infrastructure;

namespace Services.EventServices
{
    public class BookingService : Service<Booking>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public BookingService() : base(ut)
        {
        }
    }
}

