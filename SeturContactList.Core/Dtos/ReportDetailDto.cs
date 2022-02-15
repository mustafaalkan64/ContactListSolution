using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Dtos
{
    public class ReportDetailDto: BaseDto
    {
        public int RegisteredPersonCount { get; set; }
        public int RegisteredPhoneCount { get; set; }
        public Guid ReportId { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
    }
}
