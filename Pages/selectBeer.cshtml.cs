using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TM470.Data.Database_Context;
using TM470.Data.Models;
using TM470.Services;

namespace TM470.Pages
{
    [BindProperties]
    public class selectBeerModel : PageModel
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IBeerCollectionRepository _beerCollectionRepository;
        public List<beers> beers { get; set; }

        public beers beer { get; set; }

        public selectBeerModel (IBeerRepository beerRepository, IBeerCollectionRepository beerCollectionRepository)
        {
            _beerRepository = beerRepository;
            _beerCollectionRepository = beerCollectionRepository;
        }
        public void OnGet(int id)
        {
            beersService service = new beersService(_beerRepository);
            beers = service.getBeersByCountryId(id);
        }

        public void OnPost()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            _beerCollectionRepository.SaveBeerToUserCollectionById(userId, beer.Id);
            
        }
    }
}