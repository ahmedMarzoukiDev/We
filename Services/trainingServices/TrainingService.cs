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
        private static IUnitOfWork uow = new UnitOfWork(dbf);
        public TrainingService(IUnitOfWork utwk) : base(utwk)
        {
            
        }

        public IEnumerable<Training> Order(string orderParam)
        {
            if (!String.IsNullOrEmpty(orderParam))
            {
                switch (orderParam)
                {
                    case "title asc":
                        return uow.getRepository<Training>().GetAll().OrderBy(t => t.title);
                    case "title desc":
                        return uow.getRepository<Training>().GetAll().OrderByDescending(t => t.title);
                    case "date asc":
                        return uow.getRepository<Training>().GetAll().OrderBy(t => t.dateAdded);
                    case "date desc":
                        return uow.getRepository<Training>().GetAll().OrderByDescending(t => t.dateAdded);
                    case "estimated time asc":
                        return uow.getRepository<Training>().GetAll().OrderBy(t => t.estimatedTime);
                    case "estimated time desc":
                        return uow.getRepository<Training>().GetAll().OrderByDescending(t => t.estimatedTime);
                    case "difficulty asc":
                        return uow.getRepository<Training>().GetAll().OrderBy(t => t.difficultyValue);
                    case "difficulty desc":
                        return uow.getRepository<Training>().GetAll().OrderByDescending(t => t.difficultyDescription);

                    default:
                        break;
                }
            }

            return uow.getRepository<Training>().GetAll();

        }

        public IEnumerable<Training> search(string searchParam)
        {
            return uow.getRepository<Training>().GetMany(t => t.title == searchParam);
        }

        public IEnumerable<Training> filter(Category category)
        {
            return uow.getRepository<Training>().GetMany(t => t.category == category);
        }

        
    }
}
