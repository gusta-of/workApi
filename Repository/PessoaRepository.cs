﻿using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using workApi.IRepository;
using workApi.Model;

namespace workApi.Repository
{
    public class PessoaRepository : IGenericsRepository<Pessoa>
    {
        private readonly string _connectionString;

        public PessoaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Pessoa> GetAll()
        {
            using (MySqlConnection connection = new MySqlConnection(_connectionString))
            {
                return connection.Query<Pessoa>("SELECT * FROM Pessoa ORDER BY nome ASC");
            }
        }

        public Pessoa GetId(long id)
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
