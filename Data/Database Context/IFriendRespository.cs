﻿using System.Collections.Generic;
using TM470.Data.Models;

namespace TM470.Data.Database_Context
{
    public interface IFriendRespository
    {
        public List<friends> GetFriends(string userId);
        public int addFriend(string userId, friends friend);

        public int removeFriend(string userId, string friendID);
    }
}
