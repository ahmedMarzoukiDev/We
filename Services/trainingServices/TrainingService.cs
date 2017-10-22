using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.entities;
using ServicesPattern;
using We.Data.Infrastructure;

namespace Services.trainingServices
{
    public class TrainingService : Service<Training>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public TrainingService() : base(utwk)
        {
            
        }


        public IEnumerable<Training> Order(string orderParam)
        {
            if (!String.IsNullOrEmpty(orderParam))
            {
                switch (orderParam)
                {
                    case "title asc":
                        return utwk.getRepository<Training>().GetAll().OrderBy(t => t.title);
                    case "title desc":
                        return utwk.getRepository<Training>().GetAll().OrderByDescending(t => t.title);
                    case "date asc":
                        return utwk.getRepository<Training>().GetAll().OrderBy(t => t.dateAdded);
                    case "date desc":
                        return utwk.getRepository<Training>().GetAll().OrderByDescending(t => t.dateAdded);
                    case "estimated time asc":
                        return utwk.getRepository<Training>().GetAll().OrderBy(t => t.estimatedTime);
                    case "estimated time desc":
                        return utwk.getRepository<Training>().GetAll().OrderByDescending(t => t.estimatedTime);
                    case "difficulty asc":
                        return utwk.getRepository<Training>().GetAll().OrderBy(t => t.difficultyValue);
                    case "difficulty desc":
                        return utwk.getRepository<Training>().GetAll().OrderByDescending(t => t.difficultyDescription);

                    default:
                        break;
                }
            }

            return utwk.getRepository<Training>().GetAll();

        }

        public IEnumerable<Training> search(string searchParam)
        {
            return utwk.getRepository<Training>().GetMany(t => t.title == searchParam);
        }
        public Training GetLastAdded()
        {

            return (Training) utwk.getRepository<Training>().GetAll().OrderByDescending(t => t.trainingId).First();
        }
        /* public IEnumerable<Training> filter(Category category)
         {
             return utwk.getRepository<Training>().GetMany(t => t.category == category);
         }*/


    }
}
