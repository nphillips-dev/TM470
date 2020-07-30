using System.Collections.Generic;
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

        public int getUserCollectionCount(string userId)
        {
            return _beerCollectionRepository.getUserCollectionCount(userId);
        }

        public List<beersViewModel> getUserCollectionRemaining(string userId)
        {
            return _beerCollectionRepository.getUserCollectionRemaining(userId);
        }

        public int getUserCollectionRemaningCount(string userId)
        {
            return _beerCollectionRepository.getUserCollectionRemaningCount(userId);
        }

        public int SaveBeerToUserCollectionById(string userId, int beerId)
        {
            return _beerCollectionRepository.SaveBeerToUserCollectionById(userId, beerId);
        }
    }
}
