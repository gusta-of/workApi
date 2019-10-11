using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workApi.IRepository;
using workApi.IRepository.ContextWebConnection;
using workApi.Model;

namespace workApi.Repository
{
    public class PessoaRepository : RepositoryAbstrato<Pessoa>
    {
        public PessoaRepository(string connectionString) 
            : base(connectionString)
        {
        }

        public override IEnumerable<Pessoa> GetAll()
        {
            var teste = DbHelper.Instancia.RetornaTeste();

            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Pessoa>("SELECT * FROM Pessoa ORDER BY nome ASC");
            }
        }

        public override Pessoa GetId(long id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Pessoa>($"SELECT * FROM Pessoa WHERE id = {id}")
                    .Cast<Pessoa>()
                    .FirstOrDefault();
            }
        }
    }
}
