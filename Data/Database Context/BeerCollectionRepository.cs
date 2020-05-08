using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using TM470.Data.Models;

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

        public List<beersViewModel> getUserCollection(string userId)
        {
            using (IDbConnection con = Connection)
            {
                List<beersViewModel> userCollection = new List<beersViewModel>();
                con.Open();
                var query = @"SELECT * FROM beersViewModel WHERE id IN (SELECT beer_id FROM beer_collection WHERE user_id = @userId);";
                userCollection = con.Query<beersViewModel>(query, new { userId }).ToList();

                return userCollection;
            }
        }

        public int SaveBeerToUserCollectionById(string userId, int beerId)
        {
            using (IDbConnection con = Connection)
            {
                int rowId = 0;
                con.Open();
                var query = @"INSERT INTO beer_collection(user_id, beer_id)
                            VALUES(@userID, @beerId); " + "select LAST_INSERT_ID();";
                rowId = con.Execute(query, new { userId, beerId });

                return rowId;
            }
        }
    }
}
