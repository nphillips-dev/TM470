using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using TM470.Data.Database_Context;
using TM470.Data.Models;
using TM470.Services;

namespace TM470.Pages
{
    [BindProperties]
    public class DoINeedResultsModel : PageModel
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IBeerCollectionRepository _beerCollectionRepository;
        private readonly IFriendRespository _friendRepository;

        public int BeerId { get; set; }

        private beersService service;

        private List<friends> friendsList;

        public List<friends> Results { get; set; }

        public bool haveIHadTheBeer { get; set; }

        public beersViewModel selectedBeer { get; set; }

        public DoINeedResultsModel(IBeerRepository beerRepository, IBeerCollectionRepository beerCollectionRepository, IFriendRespository friendRespository)
        {
            _beerRepository = beerRepository;
            _beerCollectionRepository = beerCollectionRepository;
            _friendRepository = friendRespository;
        }
        public void OnGet(int beerId)
        {
            //passed a beer id
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            friendsList = new List<friends>();

            selectedBeer = _beerRepository.getBeerById(beerId);

            //do YOU need it -> is the beer id in getUserCollection?
            //https://stackoverflow.com/questions/1071032/searching-if-value-exists-in-a-list-of-objects-using-linq
            haveIHadTheBeer = _beerCollectionRepository.getUserCollection(userId).Any(beer => beer.beer_id == beerId);

            //do your friends need it? GetFriends (list of friends)
            friendsList = _friendRepository.GetFriends(userId);

            Results = new List<friends>();
            foreach (var friend in friendsList)
            {
                bool haveTheyHadTheBeer = _beerCollectionRepository.getUserCollection(friend.friend_id).Any(beer => beer.unique_id == selectedBeer.unique_id);

                if(!haveTheyHadTheBeer)
                {
                    Results.Add(friend);
                }
            }
            //for each friend check collectionViewModel to see if the unique beer id is present.
            // one method in this page model, to call the service which will do this work and return...  list of friends who need it.
        }
    }
}