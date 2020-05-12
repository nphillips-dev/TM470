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
        private readonly IFriendRespository _friendRespository;
        private readonly IUserRepository _userRepository;

        private beerCollectionService _beerCollectionservice;
        private friendService _friendService;

        public int userCollectionCount { get; set; }
        public int userCollectionRemainingCount { get; set; }

        public string userFriendId { get; set; }

        public DashboardModel(IBeerCollectionRepository beerCollectionRepository, IFriendRespository friendRespository, IUserRepository userRepository)
        {
            _beerCollectionRepository = beerCollectionRepository;
            _friendRespository = friendRespository;
            _userRepository = userRepository;
        }
        public void OnGet()
        {
            _beerCollectionservice = new beerCollectionService(_beerCollectionRepository);
            _friendService = new friendService(_friendRespository, _userRepository);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            userCollectionCount = _beerCollectionservice.getUserCollectionCount(userId);
            userCollectionRemainingCount = _beerCollectionservice.getUserCollectionRemaningCount(userId);
            userFriendId = _friendService.getUserFriendId(userId);
        }
    }
}