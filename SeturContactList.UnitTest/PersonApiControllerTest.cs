using AutoMapper;
using FluentValidation.TestHelper;
using Microsoft.AspNetCore.Mvc;
using Moq;
using SeturContactList.Core.Dtos;
using SeturContactList.Core.Entities;
using SeturContactList.Core.Repositories;
using SeturContactList.Core.Services;
using SeturContactList.Core.UnitOfWork;
using SeturContactList.Service.Exceptions;
using SeturContactList.Service.Mapping;
using SeturContactList.Service.Services;
using SeturContactList.Service.Validations;
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
        private List<PersonContacts> personContacts;
        private PersonDtoValidator personDtoValidator;
        private PersonContactDtoValidator personContactDtoValidator;
        private Persons newPerson;
        private PersonContacts newPersonContact;
        private PersonContacts invalidPersonContact;
        private Persons invalidPerson;
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
            personDtoValidator = new PersonDtoValidator();
            personContactDtoValidator = new PersonContactDtoValidator();
            _controller = new PersonsController(mapper, _personsService.Object, _mockPersonContactService.Object);
            persons = new List<Persons>() { new Persons()
            {
                Id = 1,
                Name = "Mustafa",
                Surname = "Alkan",
                Company = "TestCompany",
                CreatedDate = DateTime.Now,
                PersonContacts = new List<PersonContacts>()
                {
                    new PersonContacts()
                    {
                        City = "İzmir",
                        Town = "Bornova",
                        Email = "mustafaalkan64@gmail.com",
                        PersonId = 1,
                        Phone = "5553332211",
                        Lat = 35,
                        Long = 28,
                        CreatedDate = DateTime.Now,
                    },
                    new PersonContacts()
                    {
                        City = "İzmir",
                        Town = "Konak",
                        Email = "mustafaalkan64@gmail.com",
                        PersonId = 1,
                        Phone = "5553332211",
                        Lat = 35,
                        Long = 28,
                        CreatedDate = DateTime.Now,
                    }
                }
            },new Persons()
            {
                Id = 2,
                Name = "Ahmet",
                Surname = "Alkan",
                Company = "TestCompany1",
                CreatedDate = DateTime.Now,
                PersonContacts = new List<PersonContacts>()
                {
                    new PersonContacts()
                    {
                        City = "İzmir",
                        Town = "Bornova",
                        Email = "mustafaalkan64@gmail.com",
                        PersonId = 1,
                        Phone = "5553332211",
                        Lat = 35,
                        Long = 28,
                        CreatedDate = DateTime.Now,
                    }
                }
            } };

            personContacts = new List<PersonContacts>()
            {
                 new PersonContacts()
                    {
                        Id = 1,
                        City = "İzmir",
                        Town = "Bornova",
                        Email = "mustafaalkan64@gmail.com",
                        PersonId = 1,
                        Phone = "5553332211",
                        Lat = 35,
                        Long = 28,
                        Address = "Addresss",
                        CreatedDate = DateTime.Now,
                    },
                    new PersonContacts()
                    {
                        Id = 2,
                        City = "İzmir",
                        Town = "Bornova",
                        Email = "mustafaalkan64@gmail.com",
                        PersonId = 2,
                        Phone = "5553332211",
                        Lat = 35,
                        Long = 28,
                        Address = "Addresss",
                        CreatedDate = DateTime.Now,
                    }
            };

            newPerson = new Persons()
            {
                Id = 3,
                Name = "Ahmet",
                Surname = "Kaya",
                Company = "TestCompany",
                CreatedDate = DateTime.Now
            };

            newPersonContact = new PersonContacts()
            {
                Id = 3,
                City = "İzmir",
                Town = "Bornova",
                Email = "mustafaalkan64@gmail.com",
                PersonId = 1,
                Phone = "5553332211",
                Lat = 35,
                Long = 28,
                Address = "Addresss",
                CreatedDate = DateTime.Now,
            };


            invalidPersonContact = new PersonContacts()
            {
                Id = 3,
                City = "",
                Town = "",
                Email = "inValidEmail",
                PersonId = 1,
                Phone = "5553332211",
                Lat = 35,
                Long = 28,
                Address = "Addresss",
                CreatedDate = DateTime.Now,
            };

            invalidPerson = new Persons()
            {
                Id = 3,
                Name = "",
                Surname = "",
                Company = "TestCompany",
                CreatedDate = DateTime.Now
            };

        }

        [Fact]
        public async void GetPerson_ActionExecutes_ReturnOkResultWithPerson()
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

            _personsService.Setup(x => x.GetPersonsWithPersonContractListByPersonId(personId)).Throws(new NotFoundExcepiton($"Person ({personId}) not found"));
            //Act 
            Func<Task> act = () => _controller.GetById(personId);
            //Assert
            Exception ex = await Assert.ThrowsAsync<NotFoundExcepiton>(act);

            Assert.Contains($"Person ({personId}) not found", ex.Message);
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

            _personsService.Verify(x => x.GetPersonsWithPersonContractListByPersonId(personId), Times.Once);
            
            Assert.Equal(personId, returnPerson.Data.Id);
            Assert.True(returnPerson.Data.PersonContacts.Count() >= 1);
            Assert.Equal(person.Name, returnPerson.Data.Name);
        }


        [Fact]
        public async void PostPerson_ActionExecutes_ReturnCustomResponseDto_WithPersonDto()
        {
            _personsService.Setup(x => x.AddAsync(newPerson)).ReturnsAsync(newPerson);

            var personDto = mapper.Map<PersonDto>(newPerson);
            
            var validateResult = personDtoValidator.TestValidate(personDto);
            validateResult.ShouldNotHaveValidationErrorFor(person => person.Name);
            validateResult.ShouldNotHaveValidationErrorFor(person => person.Surname);
            validateResult.ShouldNotHaveValidationErrorFor(person => person.Company);

            var result = await _controller.Save(personDto);

            var createdResult = Assert.IsType<ObjectResult>(result);
            var returnPerson = Assert.IsAssignableFrom<CustomResponseDto<PersonDto>>(createdResult.Value);

            Assert.Equal(201, createdResult.StatusCode);

        }


        [Fact]
        public async void PostInvalidPerson_ActionExecutes_ReturnErrors()
        {
            var personDto = mapper.Map<PersonDto>(invalidPerson);
            var validateResult = await personDtoValidator.TestValidateAsync(personDto);
            validateResult.ShouldHaveValidationErrorFor(person => person.Name);
            validateResult.ShouldHaveValidationErrorFor(person => person.Surname);
        }


        [Theory]
        [InlineData(1)]
        public async void DeletePerson_ActionExecute_ReturnNoContent(int personId)
        {
            var person = persons.First(x => x.Id == personId);
            _personsService.Setup(x => x.GetByIdAsync(personId)).ReturnsAsync(person);
            _personsService.Setup(x => x.RemoveAsync(person));

            var removedResult = await _controller.Remove(personId);

            var objectResult = Assert.IsType<ObjectResult>(removedResult);
            Assert.Equal(204, objectResult.StatusCode);

            _personsService.Verify(x => x.RemoveAsync(person), Times.Once);
        }


        [Fact]
        public async void PostPersonContact_ActionExecutes_ReturnWithPersonContactId()
        {
            var person = persons.First(x => x.Id == newPersonContact.PersonId);
            _personsService.Setup(x => x.GetByIdAsync(newPersonContact.PersonId)).ReturnsAsync(person);

            _mockPersonContactService.Setup(x => x.AddAsync(newPersonContact)).ReturnsAsync(newPersonContact);

            var personContactDto = mapper.Map<PersonContactDto>(newPersonContact);

            var validateResult = personContactDtoValidator.TestValidate(personContactDto);
            validateResult.ShouldNotHaveValidationErrorFor(person => person.Phone);
            validateResult.ShouldNotHaveValidationErrorFor(person => person.City);
            validateResult.ShouldNotHaveValidationErrorFor(person => person.Email);
            validateResult.ShouldNotHaveValidationErrorFor(person => person.Town);

            var result = await _controller.SavePersonContact(personContactDto);

            var createdResult = Assert.IsType<OkObjectResult>(result);
            Assert.Equal(200, createdResult.StatusCode);
            Assert.NotNull(person);
        }

        [Fact]
        public async void PostInvalidPersonContactDto_ActionExecutes_ReturnErrors()
        {
            var personContactDto = mapper.Map<PersonContactDto>(invalidPersonContact);
            
            var validateResult = await personContactDtoValidator.TestValidateAsync(personContactDto);
            validateResult.ShouldHaveValidationErrorFor(person => person.City);
            validateResult.ShouldHaveValidationErrorFor(person => person.Town);
            validateResult.ShouldHaveValidationErrorFor(person => person.Email);
            validateResult.ShouldNotHaveValidationErrorFor(person => person.Phone);
        }


        [Theory]
        [InlineData(1)]
        public async void DeletePersonContact_ActionExecute_ReturnNoContent(int personContactId)
        {
            var personContact = personContacts.First(x => x.Id == personContactId);
            _mockPersonContactService.Setup(x => x.GetByIdAsync(personContactId)).ReturnsAsync(personContact);
            _mockPersonContactService.Setup(x => x.RemoveAsync(personContact));

            var noContentResult = await _controller.DeletePersonContact(personContactId);

            _mockPersonContactService.Verify(x => x.RemoveAsync(personContact), Times.Once);

            Assert.IsType<NoContentResult>(noContentResult);
        }


        [Theory]
        [InlineData(100)]
        public async void GetPersonContact_IdInValid_ReturnNotFound(int personContactId)
        {
            PersonContacts personContact = null;

            _mockPersonContactService.Setup(x => x.GetByIdAsync(personContactId)).Throws(new NotFoundExcepiton($"PersonContact ({personContactId}) not found"));

            //Act 
            Func<Task> act = () => _controller.GetPersonContact(personContactId);

            //Assert
            Exception ex = await Assert.ThrowsAsync<NotFoundExcepiton>(act);

            Assert.Contains($"PersonContact ({personContactId}) not found", ex.Message);
        }
    }
}
