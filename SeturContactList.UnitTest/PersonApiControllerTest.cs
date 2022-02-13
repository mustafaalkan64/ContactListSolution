using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SeturContactList.Core.Dtos;
using SeturContactList.Core.Entities;
using SeturContactList.Core.Repositories;
using SeturContactList.Core.Services;
using SeturContactList.Core.UnitOfWork;
using SeturContactList.Service.Mapping;
using SeturContactList.Service.Services;
using SeturContactListApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace SeturContactList.UnitTest
{
    public class PersonApiControllerTest
    {
        private readonly Mock<IGenericRepository<Persons>> _mockRepo;
        private readonly Mock<IGenericRepository<PersonContacts>> _mockPersonContactRepo;
        private readonly Mock<IPersonsRepository> _mockPersonRepo;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly Mock<IService<PersonContacts>> _mockPersonContactService;
        private readonly PersonsController _controller;
        private readonly Mock<IPersonsService> _personsService;
        private readonly IMapper mapper;
        private List<Persons> persons;
        private Persons newPerson;
        public PersonApiControllerTest()
        {
            var myProfile = new MapProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            _mockRepo = new Mock<IGenericRepository<Persons>>();
            _mockPersonRepo = new Mock<IPersonsRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _mockPersonContactRepo = new Mock<IGenericRepository<PersonContacts>>();
            _mockPersonContactService = new Mock<IService<PersonContacts>>();
            _personsService = new Mock<IPersonsService>();
            _controller = new PersonsController(mapper, _personsService.Object, _mockPersonContactService.Object);
            persons = new List<Persons>() { new Persons()
            {
                Id = 1,
                Name = "Mustafa",
                Surname = "Alkan",
                Company = "TestCompany",
                CreatedDate = DateTime.Now
            },new Persons()
            {
                Id = 2,
                Name = "Ahmet",
                Surname = "Alkan",
                Company = "TestCompany1",
                CreatedDate = DateTime.Now
            } };

            newPerson = new Persons()
            {
                Id = 3,
                Name = "Ahmet",
                Surname = "Kaya",
                Company = "TestCompany",
                CreatedDate = DateTime.Now
            };

        }

        [Fact]
        public async void GetProduct_ActionExecutes_ReturnOkResultWithProduct()
        {
            _personsService.Setup(x => x.GetAllAsync()).ReturnsAsync(persons);

            var result = await _controller.All();

            var okResult = Assert.IsType<ObjectResult>(result);

            var returnProducts = Assert.IsAssignableFrom<CustomResponseDto<List<PersonDto>>>(okResult.Value);

            Assert.Equal<int>(2, returnProducts.Data.ToList().Count);
        }

        [Theory]
        [InlineData(0)]
        public async void GetPerson_IdInValid_ReturnNotFound(int personId)
        {
            Persons person = null;

            _personsService.Setup(x => x.GetPersonsWithPersonContractListByPersonId(personId)).ReturnsAsync(person);

            var result = await _controller.GetById(personId);

            Assert.IsType<NotFoundResult>(result);
        }


        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetPerson_IdValid_ReturnOkResult(int personId)
        {
            var person = persons.First(x => x.Id == personId);

            _personsService.Setup(x => x.GetPersonsWithPersonContractListByPersonId(personId)).ReturnsAsync(person);

            var result = await _controller.GetById(personId);

            var okResult = Assert.IsType<ObjectResult>(result);

            var returnPerson = Assert.IsType<CustomResponseDto<PersonsWithPersonContractListDto>>(okResult.Value);

            Assert.Equal(personId, returnPerson.Data.Id);
            Assert.Equal(person.Name, returnPerson.Data.Name);
        }


        [Fact]
        public async void PostPerson_ActionExecutes_ReturnCustomResponseDto_WithPersonDto()
        {
            _personsService.Setup(x => x.AddAsync(newPerson)).ReturnsAsync(newPerson);

            var personDto = mapper.Map<PersonDto>(newPerson);
            var result = await _controller.Save(personDto);

            var createdResult = Assert.IsType<ObjectResult>(result);
            var returnPerson = Assert.IsAssignableFrom<CustomResponseDto<PersonDto>>(createdResult.Value);

            Assert.Equal(201, createdResult.StatusCode);

        }
    }
}
