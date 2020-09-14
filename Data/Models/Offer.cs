using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Logit_Transport.Data.Models
{
    public class Offer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CreatorId { get; set; }
        public Participant Creator { get; set; }
        //public ApplicationUser Creator { get; set; }

        [Required]
        [ForeignKey("Shipment")]
        public int ShipmentId { get; set; }

        public Shipment Shipment { get; set; }


    }
}
