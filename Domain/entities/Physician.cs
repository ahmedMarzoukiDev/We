using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Physician : User
    {
        public int PhysicianId { get; set; }
        public int field { get; set; }
        public int nbCases { get; set; }
        public string localisation { get; set; }

        public virtual ICollection<Availability> availabilities { get; set; }
        public virtual ICollection<Appointement> appointements { get; set; }





    }
}
