using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Dtos
{
    public class ReportDto: BaseDto
    {
        public DateTime RequestedDate { get; set; }
        public ReportStatusEnum ReportStatus { get; set; }
        public string ReportStatusString { get; set; }
        public ReportDetailDto ReportDetail { get; set; }
    }
}
