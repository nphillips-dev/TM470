using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace TM470.Data.Database_Context
{
    public class BeerCollectionRepository : IBeerCollectionRepository
    {
        private readonly IConfiguration _config;
        public BeerCollectionRepository(IConfiguration config)
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

        public void SaveBeerToUserCollectionById(string userId, int beerId)
        {
            using (IDbConnection con = Connection)
            {
                con.Open();
                var query = @"INSERT INTO beer_collection(user_id, beer_id)
                            VALUES(@userID, @beerId)";
                con.Execute(query, new { userId, beerId });
            }
        }
    }
}
