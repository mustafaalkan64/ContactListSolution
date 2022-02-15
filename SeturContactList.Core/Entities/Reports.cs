using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Entities
{
    public class Reports: BaseEntity
    {
        public DateTime RequestedDate { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
        public ReportDetail ReportDetail { get; set; }
    }
}
