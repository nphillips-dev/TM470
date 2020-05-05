﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM470.Data.Database_Context;

namespace TM470.Services
{
    public class beerCollectionService : IBeerCollectionRepository
    {
        private readonly IBeerCollectionRepository _beerCollectionRepository;
        public beerCollectionService(IBeerCollectionRepository beerCollectionRepository)
        {
            _beerCollectionRepository = beerCollectionRepository;
        }
        public int SaveBeerToUserCollectionById(string userId, int beerId)
        {
            return _beerCollectionRepository.SaveBeerToUserCollectionById(userId, beerId);
        }
    }
}