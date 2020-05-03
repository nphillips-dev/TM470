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

        public void SaveBeerToUserCollectionById(int userId, int beerId)
        {
            throw new NotImplementedException();
        }
    }
}
