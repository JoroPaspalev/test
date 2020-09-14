using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logit_Transport.Data.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string Town { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        public string Block { get; set; }

        public int? Floor { get; set; }

        public char? Entrance { get; set; }
    }
}
