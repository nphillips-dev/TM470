using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM470.Data.Database_Context;
using TM470.Data.Models;

namespace TM470.Services
{
    public class countriesService
    {
        private readonly ICountriesRepository _countriesRepository;
        public countriesService(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }
        public List<countries> GetAllCountries()
        {
           return _countriesRepository.getAllCountries();
        }
    }
}
