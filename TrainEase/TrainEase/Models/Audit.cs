using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainEase.Models
{
    public class Audit
    {
        public int AuditID { get; set; }
        public string TableName { get; set; }
        public int RecordID { get; set; }
        public string Action { get; set; }
        public int? UserID { get; set; }
        public DateTime DateTime { get; set; }
        public int TableNameID { get; set; }
    }

}
