﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TM470.Data.Database_Context
{
    public interface IBeerCollectionRepository
    {
        public int SaveBeerToUserCollectionById(string userId, int beerId);
    }
}