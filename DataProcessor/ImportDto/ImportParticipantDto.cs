using Logit_Transport.Data.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logit_Transport.DataProcessor.ImportDto
{
    public class ImportParticipantDto
    {
        [Required]
        [MaxLength(45)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[0-9]{4}-[0-9]{3}-[0-9]{3}")]
        public string Phone { get; set; }

        [MaxLength(45)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }
    }
}
