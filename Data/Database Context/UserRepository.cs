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
    public class UserRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        public UserRepository(IConfiguration config)
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

        public string getUserFriendId(string userId)
        {
            using (IDbConnection con = Connection)
            {
                con.Open();
                var query = "select friendId from aspnetusers where Id = @userId";
                var result = con.QueryFirstOrDefault<string>(query, new { userId });
                return result;
            }
        }

        public string getUserIdByFriendId(string friendId)
        {
            using (IDbConnection con = Connection)
            {
                con.Open();
                var query = "select Id from aspnetusers where friendId = @friendId";
                var result =  con.QueryFirstOrDefault<string>(query, new { friendId });
                return result;
            }
        }
    }
}
