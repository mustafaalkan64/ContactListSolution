using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Entities
{
    public class PersonContacts: BaseEntity
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
        [ForeignKey("PersonId")]
        public Persons Person { get; set; }
    }
}
