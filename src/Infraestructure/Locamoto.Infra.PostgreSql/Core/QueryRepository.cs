using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Npgsql;

namespace Locamoto.Infra.PostgreSql.Core
{
    public abstract class QueryRepository
    {
        private string _connectionString;

        public QueryRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected NpgsqlConnection GetConnection()
        {
            NpgsqlConnection connection = new(_connectionString);
            connection.Open();

            return connection;
        }
    }
}