﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TM470.Data.Database_Context
{
    public interface IUserRepository
    {
       public string getUserIdByFriendId(string friendId);
       public string getUserFriendId(string userId);
    }
}
