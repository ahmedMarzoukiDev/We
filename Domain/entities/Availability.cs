using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Availability
    {

        public int AvailabilityId { get; set; }
        public DateTime availDate { get; set; }
        public TimeSpan availTime { get; set; }
        public virtual Physician physicians { get; set; }
    }
}
