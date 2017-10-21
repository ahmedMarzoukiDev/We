using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Booking
    {
        public int BookingID { get; set; }

        public DateTime BookDate { get; set; }

        public int EventId { get; set; }

        public virtual Event events { get; set; }

    }
}
