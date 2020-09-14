using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Logit_Transport.Data.Models
{
    public class Driver
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{4}-[0-9]{3}-[0-9]{3}")]
        public string PhoneNumber { get; set; }

    }
}
