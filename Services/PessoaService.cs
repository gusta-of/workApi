using Dapper;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Linq;
using workApi.Helpers;
using workApi.Interfaces.ISercive;
using workApi.Model;

namespace workApi.Services
{
    public class PessoaService : IService<Pessoa>
    {
        private readonly AppDbContext _appDbContext;
        public PessoaService(IOptions<AppDbContext> appDbContext)
        {
            _appDbContext = appDbContext.Value;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            var connexao = DbHelper.Instancia.GetConnection(_appDbContext.MySqlDbConnection);
            return connexao.Query<Pessoa>("SELECT * FROM Pessoa ORDER BY nome");
        }

        public Pessoa GetId(long id)
        {
            var connexao = DbHelper.Instancia.GetConnection(_appDbContext.MySqlDbConnection);
            return connexao.Query<Pessoa>($"SELECT * FROM Pessoa WHERE id = {id}").FirstOrDefault();
        }
    }
}
