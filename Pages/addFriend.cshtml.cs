using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using TM470.Data.Database_Context;
using TM470.Data.Models;
using TM470.Services;

namespace TM470.Pages
{
    [BindProperties]
    public class addFriendModel : PageModel
    {
        private readonly IFriendRespository _friendRespository;
        private readonly IUserRepository _userRepository;

        private friendService service;

        public friends friend { get; set; }

        public addFriendModel(IFriendRespository friendRespository, IUserRepository userRepository)
        {
            _friendRespository = friendRespository;
            _userRepository = userRepository;
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                service = new friendService(_friendRespository, _userRepository);
                service.addFriend(User.FindFirst(ClaimTypes.NameIdentifier).Value, friend);
                return RedirectToPage("/Dashboard");
            }
            else
            {
                return Page();
            }
        }
    }
}