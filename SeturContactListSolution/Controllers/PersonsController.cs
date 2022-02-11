using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeturContactList.Core.Dtos;
using SeturContactList.Core.Entities;
using SeturContactList.Core.Services;
using SeturContactListApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturContactListApi.Controllers
{

    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IPersonsService _service;

        public ProductsController(IMapper mapper, IPersonsService service)
        {

            _mapper = mapper;
            _service = service;
        }


        /// GET api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetPersonsWithPersonContractList()
        {

            return CreateActionResult(await _service.GetPersonsWithPersonContractList());
        }



        [HttpGet]
        public async Task<IActionResult> All()
        {
            var persons = await _service.GetAllAsync();
            var personsDto = _mapper.Map<List<PersonDto>>(persons.ToList());
            return CreateActionResult(CustomResponseDto<List<PersonDto>>.Success(200, personsDto));
        }


        [ServiceFilter(typeof(NotFoundFilter<Persons>))]
        // GET /api/products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {


            var product = await _service.GetByIdAsync(id);
            var productsDto = _mapper.Map<PersonDto>(product);
            return CreateActionResult(CustomResponseDto<PersonDto>.Success(200, productsDto));
        }



        [HttpPost]
        public async Task<IActionResult> Save(PersonDto personDto)
        {
            var person = await _service.AddAsync(_mapper.Map<Persons>(personDto));
            var personsDto = _mapper.Map<PersonDto>(person);
            return CreateActionResult(CustomResponseDto<PersonDto>.Success(201, personsDto));
        }

        // DELETE api/persons/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var person = await _service.GetByIdAsync(id);
            await _service.RemoveAsync(person);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
