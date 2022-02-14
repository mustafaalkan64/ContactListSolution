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
using SeturContactList.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using MassTransit;

namespace SeturContactList.UnitTest
{
    public class ReportApiControllerTest
    {
        private readonly Mock<IGenericRepository<Reports>> _mockReportRepository;
        private readonly Mock<IGenericRepository<PersonContacts>> _mockPersonContactRepository;
        private readonly Mock<IService<Reports>> _mockReportsService;
        private readonly Mock<IService<ReportDetail>> _mockReportDetailService;
        private readonly Mock<IPublishEndpoint> _mockPublishEndpoint;
        private readonly IMapper mapper;
        private readonly ReportController _controller;
        private List<Reports> reports;
        private List<ReportDetail> reportDetails;
        private Reports newReport;
        private ReportDetail newReportDetail;
        public ReportApiControllerTest()
        {
            var myProfile = new MapProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            _mockReportRepository = new Mock<IGenericRepository<Reports>>();
            _mockPersonContactRepository = new Mock<IGenericRepository<PersonContacts>>();
            _mockReportsService = new Mock<IService<Reports>>();
            _mockReportDetailService = new Mock<IService<ReportDetail>>();
            _mockPublishEndpoint = new Mock<IPublishEndpoint>();
            _controller = new ReportController(_mockReportsService.Object, _mockReportDetailService.Object, _mockPublishEndpoint.Object, mapper);
            reports = new List<Reports>() { new Reports()
            {
                Id = 1,
                ReportStatus = Core.ReportStatusEnum.Preparing,
                CreatedDate = DateTime.Now,
                ReportDetail = new ReportDetail()
                {
                    Lat = 38,
                    Long = 27,
                    RegisteredPersonCount = 2,
                    RegisteredPhoneCount = 3
                },

            },
            new Reports()
            {
                Id = 2,
                ReportStatus = Core.ReportStatusEnum.Completed,
                CreatedDate = DateTime.Now,
                ReportDetail = new ReportDetail()
                {
                    Lat = 35,
                    Long = 28,
                    RegisteredPersonCount = 2,
                    RegisteredPhoneCount = 3
                },

            }

            };


            reportDetails = new List<ReportDetail>() { new ReportDetail()

               {
                    Lat = 38,
                    Long = 27,
                    RegisteredPersonCount = 2,
                    RegisteredPhoneCount = 3,
                    ReportId = 1,
                    CreatedDate = DateTime.Now
                },
                new ReportDetail()
                {
                    Lat = 35,
                    Long = 28,
                    RegisteredPersonCount = 3,
                    RegisteredPhoneCount = 5,
                    ReportId = 2,
                    CreatedDate = DateTime.Now
                }

            };

            newReport = new Reports()
            {
                Id = 3,
                ReportStatus = Core.ReportStatusEnum.Preparing,
                CreatedDate = DateTime.Now,
                ReportDetail = new ReportDetail()
                {
                    Lat = 35,
                    Long = 28,
                    RegisteredPersonCount = 2,
                    RegisteredPhoneCount = 3
                },
            };
        }

        [Fact]
        public async void GetPerson_ActionExecutes_ReturnOkResultWithPerson()
        {
            _mockReportsService.Setup(x => x.GetAllAsync()).ReturnsAsync(reports);

            var result = await _controller.All();

            var okResult = Assert.IsType<ObjectResult>(result);

            var returnProducts = Assert.IsAssignableFrom<CustomResponseDto<List<ReportDto>>>(okResult.Value);

            Assert.Equal<int>(2, returnProducts.Data.ToList().Count);
        }

        [Fact]
        public async void PostPerson_ActionExecutes_ReturnCustomResponseDto_WithPersonDto()
        {
            _mockReportsService.Setup(x => x.AddAsync(newReport)).ReturnsAsync(newReport);

            var locationDto = new LocationDto()
            {
                Lat = newReport.ReportDetail.Lat,
                Long = newReport.ReportDetail.Long
            };

            var result = await _controller.CreateReportRequest(locationDto);

            var createdResult = Assert.IsType<ObjectResult>(result);

            Assert.Equal(204, createdResult.StatusCode);

        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public async void GetReportDetail_ActionExecutes_ReturnOkResultWithReportDetails(int reportId)
        {
            var reportDetail = reportDetails.Where(x => x.ReportId == reportId).AsQueryable();
            _mockReportDetailService.Setup(x => x.GetAllAsync()).ReturnsAsync(reportDetails);
            _mockReportDetailService.Setup(x => x.Where( y => y.ReportId == reportId)).Returns(reportDetail);

            var result = await _controller.GetDetailByReportId(reportId);

            var okResult = Assert.IsType<ObjectResult>(result);

            var returnProducts = Assert.IsAssignableFrom<CustomResponseDto<List<ReportDetailDto>>>(okResult.Value);

            Assert.Single(returnProducts.Data.ToList());
        }

    }
}
