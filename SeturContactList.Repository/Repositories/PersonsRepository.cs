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

    public class PersonsRepository : GenericRepository<Persons>, IPersonsRepository
    {
        public PersonsRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Persons>> GetPersonsWithPersonContacts()
        {
            return await _context.Persons.Include(x => x.PersonContacts).ToListAsync();
        }
    }
}
