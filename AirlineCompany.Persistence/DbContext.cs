using AirlineCompany.Application.Interfaces;
using Dapper;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace AirlineCompany.Persistence
{
    public class DbContext : IDapperContext
    {
        private string connectionString;
        public DbContext(string connectionString) 
        {
            this.connectionString = connectionString;
        }
        public async Task ExecuteAsync(string sqlQuery)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            await connection.ExecuteAsync(sqlQuery);
        }

        public async Task<List<T>> GetAsync<T>(string sqlQuery)
        {
            using IDbConnection connection = new SqlConnection(connectionString);
            var result = await connection.QueryAsync<T>(sqlQuery);
            return result.ToList();
        }
    }
}
