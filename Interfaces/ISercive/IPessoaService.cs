using System.Collections.Generic;
using workApi.Model;

namespace workApi.Interfaces.ISercive
{
    public interface IPessoaService
    {
        IEnumerable<Pessoa> GetAll();
        public Pessoa GetId(long id);
    }
}
