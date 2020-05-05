﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM470.Data.Database_Context;
using TM470.Data.Models;

namespace TM470.Services
{
    public class beersService : IBeerRepository
    {
        private readonly IBeerRepository _beerRepository;
        public beersService(IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }

        public List<beers> getBeersByCountryId(int id)
        {
            return _beerRepository.getBeersByCountryId(id);
        }
    }
}