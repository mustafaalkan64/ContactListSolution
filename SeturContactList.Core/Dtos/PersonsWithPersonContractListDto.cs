using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Dtos
{
    public class PersonsWithPersonContractListDto: PersonDto
    {
        public List<PersonContactListDto> PersonContacts { get; set; }
    }
}
