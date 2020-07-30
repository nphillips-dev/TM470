using System.ComponentModel.DataAnnotations;

namespace TM470.Data.Models
{
    public class beersViewModel
    {

        [Display(Name = "Unique beer Id")]

        public int unique_id { get; set; }

        [Display(Name = "Version beer Id")]
        public int beer_id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Beer name must be 1 to 100 characters in length.")]
        public string name { get; set; }
        public int country_id { get; set; }
        public string Country { get; set; }
        public int version { get; set; }
    }
}
