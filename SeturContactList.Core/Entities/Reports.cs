using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Entities
{
    public class Reports
    {
        public Guid UUID { get; set; }
        public DateTime CreatedDate { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
    }
}
