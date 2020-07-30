using System.Collections.Generic;
using TM470.Data.Database_Context;
using TM470.Data.Models;

namespace TM470.Services
{
    public class countriesService :ICountriesRepository
    {
        private readonly ICountriesRepository _countriesRepository;
        public countriesService(ICountriesRepository countriesRepository)
        {
            _countriesRepository = countriesRepository;
        }

        public List<countries> getAllCountries()
        {
            return _countriesRepository.getAllCountries();
        }
    }
}
