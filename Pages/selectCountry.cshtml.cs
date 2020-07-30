using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using TM470.Data.Database_Context;
using TM470.Data.Models;
using TM470.Services;

namespace TM470.Pages
{
    [BindProperties]
    public class selectCountryModel : PageModel
    {

        private readonly ICountriesRepository _countriesRepository;

        public List<countries> countries { get; set; }
        public countries Country { get; set; }

        private countriesService service;

        public selectCountryModel(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }
        public void OnGet()
        {
            countries = new countriesService(_countriesRepository).getAllCountries();
        }

        public IActionResult OnPost()
        {
            if (Country.Id > 0 )
            {
                return RedirectToPage("/selectBeer", new { countryId = Country.Id });
            }
            else
            {
                countries = new countriesService(_countriesRepository).getAllCountries();
                return Page();
            }
            
        }
    }
}