﻿using Dapper;
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

        public List<beers> getBeersByCountryId(int id)
        {
            List<beers> beers = new List<beers>();
            using (IDbConnection con = Connection)
            {
                con.Open();
                var query = "select * from beers where country_id = @id";
                beers = con.Query<beers>(query, new {id}).ToList();

                return beers;
            }
        }
    }
}