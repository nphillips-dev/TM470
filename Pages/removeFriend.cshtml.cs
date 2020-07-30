using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;
using System.Security.Claims;
using TM470.Data.Database_Context;
using TM470.Data.Models;
using TM470.Services;

namespace TM470.Pages
{
    [BindProperties]
    public class removeFriendModel : PageModel
    {
        private readonly IFriendRespository _friendRespository;
        private readonly IUserRepository _userRepository;

        private friendService service;

        private string currentUser;

        public string friendId { get; set; }

        public List<friends> friendList { get; set; }

        public removeFriendModel(IFriendRespository friendRespository, IUserRepository userRepository)
        {
            _friendRespository = friendRespository;
            _userRepository = userRepository;
        }
        public void OnGet()
        {
            currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            friendList = _friendRespository.GetFriends(currentUser);
        }

        public IActionResult OnPost()
        {
            currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (ModelState.IsValid)
            {
                service = new friendService(_friendRespository, _userRepository);
                var result = service.removeFriend(currentUser, friendId);
                return RedirectToPage("/removeFriend");
            }
            else
            {
                currentUser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                friendList = _friendRespository.GetFriends(currentUser);
                return Page();
            }
        }
    }
}