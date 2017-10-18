using Domain.entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WeContext : DbContext
    {
        public WeContext() : base("name=ConnectionStringName")
        {
            Database.SetInitializer(new WeContextIntializer());
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Training> Trainings { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }

        public DbSet<Appointement> Appointements { get; set; }
        public DbSet<Availability> Availabilities { get; set; }

        public DbSet<Case> Cases { get; set; }

    }

    public class WeContextIntializer : DropCreateDatabaseIfModelChanges<WeContext>
    {
        protected override void Seed(WeContext context)
        {
            base.Seed(context);
        }

    }
}
