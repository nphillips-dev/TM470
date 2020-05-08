using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM470.Data.Database_Context;
using TM470.Data.Models;

namespace TM470.Services
{
    public class beerCollectionService : IBeerCollectionRepository
    {
        private readonly IBeerCollectionRepository _beerCollectionRepository;
        public beerCollectionService(IBeerCollectionRepository beerCollectionRepository)
        {
            _beerCollectionRepository = beerCollectionRepository;
        }

        public List<beersViewModel> getUserCollection(string userId)
        {
           return _beerCollectionRepository.getUserCollection(userId);
        }

        public int SaveBeerToUserCollectionById(string userId, int beerId)
        {
            return _beerCollectionRepository.SaveBeerToUserCollectionById(userId, beerId);
        }
    }
}
