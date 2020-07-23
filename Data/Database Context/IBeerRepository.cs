using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TM470.Data.Models;

namespace TM470.Data.Database_Context
{
    public interface IBeerRepository
    {
        List<beersViewModel> getBeersByCountryId(int id);

        beersViewModel getBeerById(int id);
    }
}
