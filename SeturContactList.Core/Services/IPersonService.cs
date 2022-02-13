using SeturContactList.Core.Dtos;
using SeturContactList.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Core.Services
{
    public interface IPersonsService : IService<Persons>
    {
        Task<CustomResponseDto<List<PersonsWithPersonContractListDto>>> GetPersonsWithPersonContractList();
        Task<Persons> GetPersonsWithPersonContractListByPersonId(int personId);
    }
}
