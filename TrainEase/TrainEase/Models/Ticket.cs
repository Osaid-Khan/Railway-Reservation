using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEase.Models
{
    public class Ticket
    {
        public int TicketID { get; set; }
        public int TrainID { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
