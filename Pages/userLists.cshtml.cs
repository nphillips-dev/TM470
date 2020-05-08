using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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
            //https://stackoverflow.com/questions/2745544/remove-items-from-one-list-in-another
            setPageVariables();
            service = new beerCollectionService(_beerCollectionRepository);
            beers = service.getUserCollection(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }



        private void setPageVariables()
        {
            type = Request.Query["type"];
            if (string.IsNullOrEmpty(type))
            {
                type = "list";
            }

            title = type.Equals("list") ? "List of beers you have tried" : "List of beers you have left to try";
        }
    }
}