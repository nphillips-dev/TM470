using System.ComponentModel.DataAnnotations;

namespace TM470.Data.Models
{
    public class beerCollection
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int user_id { get; set; }

        [Required]
        public int beer_id { get; set; }
    }
}
