using System.ComponentModel.DataAnnotations;

namespace TM470.Data.Models
{
    public class countries
    {

        [Key]
        [Display(Name = "Country Id")]
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Country must be 1 to 50 characters in length.")]
        public string Country { get; set; }
    }
}
