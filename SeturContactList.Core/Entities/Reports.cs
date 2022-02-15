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
        public int? ReportStatus { get; set; } = (int)ReportStatusEnum.Preparing;
        public ReportDetail ReportDetail { get; set; }
    }
}
