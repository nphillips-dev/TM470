using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM470.Data.Models;

namespace TM470.Data.Database_Context
{
    public interface IFriendRespository
    {
        public int addFriend(string userId, string friendID);

        public int removeFriend(string userId, string friendID);
    }
}
