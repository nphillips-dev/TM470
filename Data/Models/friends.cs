using System.ComponentModel.DataAnnotations;

namespace TM470.Data.Models
{
    public class friends
    {
        [Key]
        public int Id { get; set; }

        public string user_id { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "Friend ID must be 8 characters in length.")]
        public string friend_id { get; set; }

        [Required]
        [StringLength(255, ErrorMessage = "Nickname must be 1 to 255 characters in length.")]
        public string nickname { get; set; }
    }
}
