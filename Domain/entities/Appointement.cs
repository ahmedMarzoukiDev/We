using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Appointement

    {

        public int AppointementId { get; set; }
        public DateTime appoinDate { get; set; }
        // liste apartir de la disponibilité 
        public TimeSpan appoinTime { get; set; }

        public bool state { get; set; }

        public string appoinAddress { get; set; }
        public virtual Physician physician { get; set; }
        public virtual Case mcase { get; set; }



        // delete si fét date ta3  appointement 


    }
}
