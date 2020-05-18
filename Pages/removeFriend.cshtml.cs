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
    public class removeFriendModel : PageModel
    {
        private readonly IFriendRespository _friendRespository;
        private readonly IUserRepository _userRepository;

        private friendService service;

        [BindProperty]
        public string friendId { get; set; }

        public removeFriendModel(IFriendRespository friendRespository, IUserRepository userRepository)
        {
            _friendRespository = friendRespository;
            _userRepository = userRepository;
        }
        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (!string.IsNullOrEmpty(friendId))
            {
                if (friendId.Length >= 8)
                {
                    service = new friendService(_friendRespository, _userRepository);
                    var result = service.removeFriend(User.FindFirst(ClaimTypes.NameIdentifier).Value, friendId);
                    return RedirectToPage("/Dashboard");
                }
                else
                {
                    ModelState.AddModelError("lengthError", "Check the Id entered is the correct length");
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError("nullError", "Enter your friend's Id");
                return Page();
            }

        }
    }
}