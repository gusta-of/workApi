using Dapper;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workApi.Helpers;
using workApi.Interfaces.ISercive;
using workApi.IRepository.ContextWebConnection;
using workApi.Model;

namespace workApi.Services
{
    public class PessoaService : IPessoaService
    {
        private readonly string _connectionString;
        public PessoaService(string stringDeConexao)
        {
            _connectionString = stringDeConexao;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            var connexao = DbHelper.Instancia.GetConnection(_connectionString);
            return connexao.Query<Pessoa>("SELECT * FROM Pessoa ORDER BY nome");
        }

        public Pessoa GetId(long id)
        {
            var connexao = DbHelper.Instancia.GetConnection(_connectionString);
            return connexao.Query<Pessoa>($"SELECT * FROM Pessoa WHERE id = {id}").FirstOrDefault();
        }
    }
}
