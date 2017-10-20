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
    public class QuestionService : Service<Question>
    {
        private static IDatabaseFactory dbf = new DatabaseFactory();
        private static IUnitOfWork utwk = new UnitOfWork(dbf);
        public QuestionService() : base(utwk)
        {

        }
    }
}
