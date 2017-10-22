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
    public class EventService : Service<Event>
    {

        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork ut = new UnitOfWork(dbf);

        public EventService() : base(ut)
        {
        }
        public IEnumerable<Event> GetEventsByName(string eventName)
        {
            return ut.getRepository<Event>().GetMany(x => x.EventName == eventName);
        }


        public IEnumerable<Event> GetEventsByID(int eventId)
        {
            return ut.getRepository<Event>().GetMany(x => x.EventID == eventId);
        }
    }
}