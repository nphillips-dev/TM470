using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TM470.Data.Models;

namespace TM470.Data.Database_Context
{
    public class CountriesRepository : ICountriesRepository
    {
        private readonly IConfiguration _config;
        public CountriesRepository(IConfiguration config)
        {
            _config = config;
        }

        public IDbConnection Connection
        {
            get
            {
                return new MySqlConnection(_config.GetConnectionString("TM470ContextConnection"));
            }
        }

        public List<countries> getAllCountries()
        {
            List<countries> countries = new List<countries>();
            using (IDbConnection con = Connection)
            {
                con.Open();
                var query = "select * from countries";
                countries = con.Query<countries>(query).ToList();

                return countries;
            }
        }
    }
}
