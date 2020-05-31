using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TM470.Data.Models
{
    public class beers
    {
        [Key]
        [Display(Name = "Beer Id")]
        public int Id { get; set; }

        [Display(Name = "Unique beer Id")]
        public string unique_beer_id { get; set; }
        /*

        [Required]
        [Display(Name = "Country Id")]
        public int country_id { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Beer name must be 1 to 100 characters in length.")]
        public string name { get; set; }
        */

        [Required]
        public int version { get; set; }
    }
}
