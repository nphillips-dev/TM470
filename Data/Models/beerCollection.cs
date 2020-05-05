using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

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
