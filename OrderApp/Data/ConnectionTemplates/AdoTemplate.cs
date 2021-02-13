using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Optional;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderApp.Data.ConnectionTemplates
{
    public abstract class AdoTemplate<T>
    {
        private IConfiguration _config;

        public AdoTemplate(IConfiguration configuration) 
        {
            _config = configuration;
        }

        public async Task<List<T>> Query( string query ) 
        {
            string connectionString = _config.GetConnectionString("Default");
            using var connection = new MySqlConnection(connectionString);
            return (await connection.QueryAsync<T>(query)).AsList();
        }

        public async Task<Option<T>> QueryForObject(string query)
        {
            string connectionString = _config.GetConnectionString("Default");
            using var connection = new MySqlConnection(connectionString);
            return Option.Some(await connection.QueryFirstAsync<T>(query));
        }
    }
}
