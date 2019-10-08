using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workApi.IRepository;
using workApi.Model;

namespace workApi.Repository
{
    public class OperadorRepository : RepositoryAbstrato<Operador>
    {
        public OperadorRepository(string connectionString) 
            : base(connectionString)
        {
        }

        public override IEnumerable<Operador> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Operador>("SELECT * FROM Operador ORDER BY nome ASC");
            }
        }

        public override Operador GetId(long id)
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Operador>($"SELECT * FROM Operador WHERE id = {id}")
                    .Cast<Operador>()
                    .FirstOrDefault();
            }
        }
    }
}
