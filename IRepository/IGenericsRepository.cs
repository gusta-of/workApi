using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workApi.Model;

namespace workApi.IRepository
{
    interface IGenericsRepository<T>
    {
        IEnumerable<T> GetAll();
        T GetId(long id);
    }
}
