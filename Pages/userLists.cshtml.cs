using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using TM470.Data.Database_Context;
using TM470.Data.Models;
using TM470.Services;

namespace TM470.Pages
{
    public class userListsModel : PageModel
    {
        private readonly IBeerCollectionRepository _beerCollectionRepository;
        public List<beersViewModel> beers { get; set; }

        public string title;
        public string type;


        private beerCollectionService service;

        public userListsModel(IBeerCollectionRepository beerCollectionRepository)
        {
            _beerCollectionRepository = beerCollectionRepository;
        }
        public void OnGet()
        {
            setPageVariables();
            service = new beerCollectionService(_beerCollectionRepository);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (type.Equals("tried"))
            {
                beers = service.getUserCollection(userId);
            }
            else
            {
                beers = service.getUserCollectionRemaining(userId);
            }
            
        }



        private void setPageVariables()
        {
            type = Request.Query["type"];
            if (string.IsNullOrEmpty(type))
            {
                type = "tried";
            }

            title = type.Equals("tried") ? "List of beers you have tried" : "List of beers you have left to try";
        }
    }
}