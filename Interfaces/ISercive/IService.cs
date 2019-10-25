using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace workApi.Interfaces.ISercive
{
    public interface IService<T>
    {
        IEnumerable<T> GetAll();
        public T GetId(long id);
    }
}
