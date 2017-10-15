
using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace We.Data.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        WeContext DataContext { get; }
    }

}
