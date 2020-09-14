using System;
using System.Collections.Generic;
using System.Text;

namespace Logit_Transport.Data.Models
{
    public class Shipment
    {
        public int Id { get; set; }

        public int CountOfPackages { get; set; }

        public string Description { get; set; }

        public double Width { get; set; }

        public double Length { get; set; }

        public double Hight { get; set; }

        public double Weight { get; set; }

        public decimal Price { get; set; }

        public string Comment { get; set; }

        public bool IsFragile { get; set; }

        public bool IsDelivered { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime LoadingDate { get; set; }

        public DateTime DeliveryDate { get; set; }

        public int SenderId { get; set; }
        public virtual Participant Sender { get; set; }

        public int ReceiverId { get; set; }
        public virtual Participant Receiver { get; set; }

        public int PayerId { get; set; }
        public virtual Participant Payer { get; set; }

        public int DriverId { get; set; }

        public virtual Driver Driver { get; set; }



    }
}
