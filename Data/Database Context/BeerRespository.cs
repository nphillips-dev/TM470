using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TM470.Data.Models;

namespace TM470.Data.Database_Context
{
    public class BeerRespository : IBeerRepository
    {
        private readonly IConfiguration _config;
        public BeerRespository(IConfiguration config)
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

        public beersViewModel getBeerById(int id)
        {
            using (IDbConnection con = Connection)
            {
                con.Open();
                var query = "select * from beersViewModel where beer_id = @id";
                return con.Query<beersViewModel>(query, new { id }).FirstOrDefault();
            }
        }

        public List<beersViewModel> getBeersByCountryId(int id)
        {
            List<beersViewModel> beers = new List<beersViewModel>();
            using (IDbConnection con = Connection)
            {
                con.Open();
                var query = "select * from beersViewModel where country_id = @id";
                beers = con.Query<beersViewModel>(query, new {id}).ToList();

                return beers;
            }
        }
    }
}
