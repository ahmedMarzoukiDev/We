using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.entities
{
    public class Category
    {
        public int categoryId { get; set; }
        public string name { get; set; }
        public ICollection<Training> trainings { get; set; }
    }
}
