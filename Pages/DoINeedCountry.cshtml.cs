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
    public class DoINeedCountryModel : PageModel
    {
        private readonly ICountriesRepository _countriesRepository;

        public List<countries> countries { get; set; }
        public countries Country { get; set; }

        private countriesService service;

        public DoINeedCountryModel(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }
        public void OnGet()
        {
            countries = new countriesService(_countriesRepository).getAllCountries();
        }

        public IActionResult OnPost()
        {
            if (Country.Id > 0)
            {
                return RedirectToPage("/DoINeedBeer", new { countryId = Country.Id });
            }
            else
            {
                countries = new countriesService(_countriesRepository).getAllCountries();
                return Page();
            }

        }
    }
}