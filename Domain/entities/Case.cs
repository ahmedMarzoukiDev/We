using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Case
    {
        public int CaseId { get; set; }
        //liste des nom des medecin 
        public string physicianName { get; set; }
        public string decription { get; set; }
        public string titre { get; set; }
        public bool state { get; set; }
        public virtual ICollection<Appointement> appointementss { get; set; }





    }
}
