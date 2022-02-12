using Microsoft.EntityFrameworkCore;
using SeturContactList.Core.Entities;
using SeturContactList.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Repository.Repositories
{

    public class PersonContactRepository : GenericRepository<PersonContacts>, IPersonContactRepository
    {
        public PersonContactRepository(AppDbContext context) : base(context)
        {
        }
    }
}
