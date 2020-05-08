using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TM470.Data.Database_Context;
using TM470.Services;

namespace TM470.Pages
{
    public class DashboardModel : PageModel
    {

        private readonly IBeerCollectionRepository _beerCollectionRepository;

        private beerCollectionService service;

        public int userCollectionCount { get; set; }

        public DashboardModel(IBeerCollectionRepository beerCollectionRepository)
        {
            _beerCollectionRepository = beerCollectionRepository;
        }
        public void OnGet()
        {
            service = new beerCollectionService(_beerCollectionRepository);
            userCollectionCount = service.getUserCollectionCount(User.FindFirst(ClaimTypes.NameIdentifier).Value);
        }
    }
}