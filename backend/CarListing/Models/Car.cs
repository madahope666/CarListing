using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarListing.Models
{
    public partial class Car
    {
        public int Carid { get; set; }
        [Required]
        [StringLength(255)]
        public string Brand { get; set; }
        [Required]
        [StringLength(255)]
        public string ModelYear { get; set; }
    }
}
