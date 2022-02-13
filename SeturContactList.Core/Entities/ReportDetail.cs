using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Entities
{
    public class ReportDetail: BaseEntity
    {
        public int RegisteredPersonCount { get; set; }
        public int RegisteredPhoneCount { get; set; }
        public int ReportId { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public Reports Report { get; set; }
    }
}
