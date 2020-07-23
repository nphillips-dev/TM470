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

        [Required]
        public int version { get; set; }
    }
}
