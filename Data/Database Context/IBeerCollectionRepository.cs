using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM470.Data.Models;

namespace TM470.Data.Database_Context
{
    public interface IBeerCollectionRepository
    {
        public int SaveBeerToUserCollectionById(string userId, int beerId);
        List<beersViewModel> getUserCollection(string userId);
        public int getUserCollectionCount(string userId);

        List<beersViewModel> getUserCollectionRemaining(string userId);
        public int getUserCollectionRemaningCount(string userId);
    }
}
