using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Events
{
    public class ReportRequestCreatedEvent
    {
        public int ReportId { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
    }
}
