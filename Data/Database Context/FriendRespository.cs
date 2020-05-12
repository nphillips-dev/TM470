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
    public class FriendRespository : IFriendRespository
    {
        private readonly IConfiguration _config;
        public FriendRespository(IConfiguration config)
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
        public int addFriend(string userId, string friendID)
        {
            using (IDbConnection con = Connection)
            {
                int rowId = 0;
                con.Open();
                var query = @"INSERT INTO friend_ids(user_id, friend_id)
                            VALUES(@userID, @friendId); " + "select LAST_INSERT_ID();";
                rowId = con.Execute(query, new { userId, friendID });

                return rowId;
            }
        }
    }
}
