using SeturContactList.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Repositories
{
    public interface IPersonsRepository : IGenericRepository<Persons>
    {
        Task<List<Persons>> GetPersonsWithPersonContacts();
        Task<Persons> GetPersonsWithPersonContactsByPersonId(Guid personId);
    }
}
