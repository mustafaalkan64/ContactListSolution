using AutoMapper;
using SeturContactList.Core.Dtos;
using SeturContactList.Core.Entities;
using SeturContactList.Core.Repositories;
using SeturContactList.Core.Services;
using SeturContactList.Core.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.Service.Services
{
    public class PersonContactService : Service<PersonContacts>, IPersonContactService
    {
        private readonly IPersonContactRepository _personContactRepository;
        private readonly IMapper _mapper;

        public PersonContactService(IGenericRepository<PersonContacts> repository, IUnitOfWork unitOfWork, IMapper mapper, IPersonContactRepository personContactRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _personContactRepository = personContactRepository;
        }
    }
}
