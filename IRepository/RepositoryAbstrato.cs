using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workApi.Model;

namespace workApi.IRepository
{
    public abstract class RepositoryAbstrato<T> : IRepository
    {
        protected string _connectionString;
        public RepositoryAbstrato(string connectionString)
        {
            _connectionString = connectionString;
        }

        public abstract IEnumerable<T> GetAll();
        public abstract T GetId(long id);
    }
}
