using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workApi.Model;

namespace workApi.Interfaces.ISercive
{
    public interface IOperadorService
    {
        Operador Autentique(string username, string senha);
        IEnumerable<Operador> GetAll();
    }
}
