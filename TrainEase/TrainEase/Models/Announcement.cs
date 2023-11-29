using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEase.Models
{
    public class Announcement
    {
        public int AnnouncementID { get; set; }
        public int TrainID { get; set; }
        public string AnnouncementText { get; set; }
        public DateTime AnnouncementTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

}
