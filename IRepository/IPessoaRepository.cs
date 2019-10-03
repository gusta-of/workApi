using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workApi.Model;

namespace workApi.IRepository
{
    interface IPessoaRepository
    {
        IEnumerable<Pessoa> GetAll();
    }
}
