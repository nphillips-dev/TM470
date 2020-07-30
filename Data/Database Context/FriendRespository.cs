using Dapper;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TM470.Data.Models;

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
        public int addFriend(string userId, friends friend)
        {
            using (IDbConnection con = Connection)
            {
                int rowId = 0;
                con.Open();
                var query = @"INSERT INTO friends(user_id, friend_id, nickname)
                            VALUES(@userId, @user_id, @nickname); " + "select LAST_INSERT_ID();";
                rowId = con.Execute(query, new { userId, friend.user_id, friend.nickname });

                return rowId;
            }
        }
        public int removeFriend(string userId, string friendID)
        {
            using (IDbConnection con = Connection)
            {
                int rowId = 0;
                con.Open();
                var query = @"DELETE from friends where user_id = @userId AND friend_id = @friendId;";
                rowId = con.ExecuteScalar<int>(query, new { userId, friendID });
                return rowId;
            }

        }

        public List<friends> GetFriends(string userId)
        {
            using (IDbConnection con = Connection)
            {
                List<friends> friendList = new List<friends>();
                con.Open();
                var query = @"SELECT * FROM friends WHERE user_id = @userId;";
                friendList = con.Query<friends>(query, new { userId }).ToList();

                return friendList;
            }
        }

    }
}
