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
    [BindProperties]
    public class DoINeedBeerModel : PageModel
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IBeerCollectionRepository _beerCollectionRepository;

        public int CountryId { get; set; }
        public List<beersViewModel> beers { get; set; }

        public int selectedBeerId { get; set; }

        private beersService service;

        public DoINeedBeerModel(IBeerRepository beerRepository, IBeerCollectionRepository beerCollectionRepository)
        {
            _beerRepository = beerRepository;
            _beerCollectionRepository = beerCollectionRepository;
        }
        public void OnGet(int countryId)
        {
            service = new beersService(_beerRepository);
            beers = service.getBeersByCountryId(countryId);
            CountryId = countryId;
        }

        public IActionResult OnPost()
        {
            string userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (selectedBeerId > 0)
            {
                int savedRowId = _beerCollectionRepository.SaveBeerToUserCollectionById(userId, selectedBeerId);

                if (savedRowId > 0)
                {
                    return RedirectToPage("/DoINeedResults");
                }
                else
                {
                    ModelState.AddModelError("SaveError", "An error prevented your request from saving, try again");
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError("SelectError", "Select a beer");
                beers = new beersService(_beerRepository).getBeersByCountryId(CountryId);
                return Page();
            }
        }
    }
}