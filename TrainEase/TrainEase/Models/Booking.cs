using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEase.Models
{
    public class Booking
    {
        public int BookingID { get; set; }
        public int UserID { get; set; }
        public int TrainID { get; set; }
        public int SeatNumber { get; set; }
        public decimal Price { get; set; }
        public DateTime BookingTime { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
