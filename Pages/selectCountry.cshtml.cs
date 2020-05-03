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
    public class selectCountryModel : PageModel
    {
        private readonly ICountriesRepository _countriesRepository;

        [BindProperty]
        public List<countries> countries { get; set; }

        public selectCountryModel(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }
        public void OnGet()
        {
            countriesService service = new countriesService(_countriesRepository);
            countries = service.GetAllCountries();
        }
    }
}