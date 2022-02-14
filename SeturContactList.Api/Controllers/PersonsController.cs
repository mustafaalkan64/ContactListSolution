using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeturContactList.Api.Filters;
using SeturContactList.Core.Dtos;
using SeturContactList.Core.Entities;
using SeturContactList.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturContactList.Api.Controllers
{

    public class PersonsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPersonsService _personService;
        private readonly IService<PersonContacts> _personContactService;

        public PersonsController(IMapper mapper, IPersonsService personService, IService<PersonContacts> personContactService)
        {

            _mapper = mapper;
            _personService = personService;
            _personContactService = personContactService;
        }


        /// GET api/products/GetProductsWithCategory
        [HttpGet("getPersonsWithContacts")]
        public async Task<IActionResult> GetPersonsWithPersonContactList()
        {
            return CreateActionResult(await _personService.GetPersonsWithPersonContractList());
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var persons = await _personService.GetAllAsync();
            var personsDto = _mapper.Map<List<PersonDto>>(persons.ToList());
            return CreateActionResult(CustomResponseDto<List<PersonDto>>.Success(200, personsDto));
        }


        [ServiceFilter(typeof(NotFoundFilter<Persons>))]
        // GET /api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var person = await _personService.GetPersonsWithPersonContractListByPersonId(id);
            var personsDto = _mapper.Map<PersonsWithPersonContractListDto>(person);
            return CreateActionResult(CustomResponseDto<PersonsWithPersonContractListDto>.Success(200, personsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {
            var person = await _personService.AddAsync(_mapper.Map<Persons>(personDto));
            var personsDto = _mapper.Map<PersonDto>(person);
            return CreateActionResult(CustomResponseDto<PersonDto>.Success(201, personsDto));
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var person = await _personService.GetByIdAsync(id);
            await _personService.RemoveAsync(person);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }


        [HttpPost("SavePersonContact")]
        public async Task<IActionResult> SavePersonContact(PersonContactDto personContactDto)
        {
            //var person = await _personService.GetByIdAsync(personContactDto.PersonId);
            var personContact = _mapper.Map<PersonContacts>(personContactDto);
            await _personContactService.AddAsync(personContact);
            return Ok(personContact.Id);
        }



        [HttpDelete("deletePersonContact")]
        public async Task<IActionResult> DeletePersonContact(int id)
        {
            var personContact = await _personContactService.GetByIdAsync(id);
            await _personContactService.RemoveAsync(personContact);
            return NoContent();
        }


        [HttpGet("getPersonContact")]
        public async Task<IActionResult> GetPersonContact(int id)
        {
            var personContact = await _personContactService.GetByIdAsync(id);
            return CreateActionResult(CustomResponseDto<PersonContacts>.Success(204, personContact));
        }
    }
}
