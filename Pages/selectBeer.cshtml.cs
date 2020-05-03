using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TM470.Data.Database_Context;
using TM470.Data.Models;
using TM470.Services;

namespace TM470.Pages
{
    public class selectBeerModel : PageModel
    {
        private readonly IBeerRepository _beerRepository;
        public List<beers> beers { get; set; }

        public beers beer { get; set; }

        public selectBeerModel (IBeerRepository beerRepository)
        {
            _beerRepository = beerRepository;
        }
        public void OnGet(int id)
        {
            beersService service = new beersService(_beerRepository);
            beers = service.getBeersByCountryId(id);
        }

        public void OnPost()
        {
            var userId = User.Identity.Name;
        }
    }
}