using Domain.entities;
using ServicesPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using We.Data.Infrastructure;

namespace Services.trainingServices
{
    public class LessonService : Service<Lesson>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public LessonService() : base(utwk)
        {
        }

        public Lesson GetLastAdded()
        {
            return (Lesson)utwk.getRepository<Lesson>().GetAll().OrderByDescending(t => t.dateAdded).First();
        }

    }
}
