using Domain.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Configurations
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            //properties configuration

            Property(p => p.EventID).IsRequired();

            Property(p => p.EventName).HasMaxLength(50).IsRequired();

            Property(p => p.Address).HasMaxLength(50).IsOptional();

            Property(p => p.Description).HasMaxLength(50).IsOptional();





        }
    }
}
