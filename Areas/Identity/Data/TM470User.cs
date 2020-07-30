using Microsoft.AspNetCore.Identity;

namespace TM470.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the TM470User class
    public class TM470User : IdentityUser
    {
        public string bookVersion { get; set; }
        public string friendId { get; set; }
    }
}
