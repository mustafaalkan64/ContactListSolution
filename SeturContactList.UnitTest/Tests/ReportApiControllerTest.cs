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

namespace SeturContactList.UnitTest.Tests
{
    public class ReportApiControllerTest
    {
        private readonly Mock<IService<Reports>> _mockReportsService;
        private readonly Mock<IService<ReportDetail>> _mockReportDetailService;
        private readonly Mock<IPublishEndpoint> _mockPublishEndpoint;
        private readonly IMapper mapper;
        private readonly ReportController _controller;
        private List<Reports> reports;
        private List<ReportDetail> reportDetails;
        private Reports newReport;
        private ReportDetail newReportDetail;
        private Guid newReportId1 = Guid.NewGuid();
        private Guid newReportId2 = Guid.NewGuid();
        public ReportApiControllerTest()
        {
            var myProfile = new MapProfile();
            var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
            mapper = new Mapper(configuration);

            _mockReportsService = new Mock<IService<Reports>>();
            _mockReportDetailService = new Mock<IService<ReportDetail>>();
            _mockPublishEndpoint = new Mock<IPublishEndpoint>();
            _controller = new ReportController(_mockReportsService.Object, _mockReportDetailService.Object, _mockPublishEndpoint.Object, mapper);
            reports = new List<Reports>() { new Reports()
            {
                Id = newReportId1,
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
                    Id = newReportId2,
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
                    Id = Guid.NewGuid(),
                    Lat = 38,
                    Long = 27,
                    RegisteredPersonCount = 2,
                    RegisteredPhoneCount = 3,
                    ReportId = newReportId1,
                    CreatedDate = DateTime.Now
                },
                new ReportDetail()
                {
                    Id = Guid.NewGuid(),
                    Lat = 35,
                    Long = 28,
                    RegisteredPersonCount = 3,
                    RegisteredPhoneCount = 5,
                    ReportId = newReportId2,
                    CreatedDate = DateTime.Now
                }

            };

            newReport = new Reports()
            {
                Id = Guid.NewGuid(),
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
        public async void GetReports_ActionExecutes_ReturnOkResultWithReports()
        {
            _mockReportsService.Setup(x => x.GetAllAsync()).ReturnsAsync(reports);

            var result = await _controller.All();

            var okResult = Assert.IsType<ObjectResult>(result);

            var returnProducts = Assert.IsAssignableFrom<CustomResponseDto<List<ReportDto>>>(okResult.Value);

            Assert.Equal<int>(2, returnProducts.Data.ToList().Count);
        }

        [Fact]
        public async void PostReport_ActionExecutes_ReturnCustomResponseDto_WithReportDto()
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

        [Fact]
        public async void GetReportDetail_ActionExecutes_ReturnOkResultWithReportDetails()
        {
            var reportDetail = reportDetails.Where(x => x.ReportId == newReportId1).AsQueryable();
            _mockReportDetailService.Setup(x => x.GetAllAsync()).ReturnsAsync(reportDetails);
            _mockReportDetailService.Setup(x => x.Where(y => y.ReportId == newReportId1)).Returns(reportDetail);

            var result = await _controller.GetDetailByReportId(newReportId1);

            var okResult = Assert.IsType<ObjectResult>(result);

            var returnProducts = Assert.IsAssignableFrom<CustomResponseDto<List<ReportDetailDto>>>(okResult.Value);
        }

    }
}
