using AutoMapper;
using SeturContactList.Core.Dtos;
using SeturContactList.Core.Entities;
using SeturContactList.Core.Repositories;
using SeturContactList.Core.Services;
using SeturContactList.Core.UnitOfWork;
using SeturContactList.Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Service.Services
{
    public class PersonsService : Service<Persons>, IPersonsService
    {
        private readonly IPersonsRepository _personRepository;
        private readonly IMapper _mapper;

        public PersonsService(IGenericRepository<Persons> repository, IUnitOfWork unitOfWork, IMapper mapper, IPersonsRepository personRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _personRepository = personRepository;
        }

        public async Task<CustomResponseDto<List<PersonsWithPersonContractListDto>>> GetPersonsWithPersonContractList()
        {
            var persons = await _personRepository.GetPersonsWithPersonContacts();

            var personsDto = _mapper.Map<List<PersonsWithPersonContractListDto>>(persons);
            return CustomResponseDto<List<PersonsWithPersonContractListDto>>.Success(200, personsDto);
        }

        public async Task<Persons> GetPersonsWithPersonContractListByPersonId(int personId)
        {
            var person = await _personRepository.GetPersonsWithPersonContactsByPersonId(personId);
            if (person == null)
            {
                throw new NotFoundExcepiton($"Person not found");
            }
            return person;
        }
    }
}
