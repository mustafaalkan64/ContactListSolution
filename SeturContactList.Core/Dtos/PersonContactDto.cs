using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Dtos
{
    public class PersonContactDto: BaseDto
    {
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string Info { get; set; }
        public string City { get; set; }
        public string Town { get; set; }
        public decimal Lat { get; set; }
        public decimal Long { get; set; }
        public int PersonId { get; set; }
    }
}
