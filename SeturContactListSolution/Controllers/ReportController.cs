using AutoMapper;
using MassTransit;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SeturContactList.Core;
using SeturContactList.Core.Dtos;
using SeturContactList.Core.Entities;
using SeturContactList.Core.Events;
using SeturContactList.Core.Services;
using SeturContactListApi.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturContactListApi.Controllers
{

    public class ReportController : CustomBaseController
    {
        private readonly IService<Reports> _reportService;
        private readonly IPublishEndpoint _publishEndpoint;

        public ReportController(IService<Reports> reportService, IPublishEndpoint publishEndpoint)
        {
            _reportService = reportService;
            _publishEndpoint = publishEndpoint;
        }

        [HttpPost("CreateReportRequest")]
        public async Task<IActionResult> CreateReportRequest([FromBody] LocationDto locationDto)
        {
            var newReportRequest = new Reports()
            {
                ReportStatus = ReportStatusEnum.Preparing,
                RequestedDate = DateTime.Now
            };
            await _reportService.AddAsync(newReportRequest);

            ReportRequestCreatedEvent reportCreatedEvent = new ReportRequestCreatedEvent()
            {
                Lat = locationDto.Lat,
                Long = locationDto.Long,
                ReportId = newReportRequest.Id
            };
            await _publishEndpoint.Publish(reportCreatedEvent);
            return CreateActionResult(CustomResponseDto<NoContentDto>.Success(204));
        }

    }
}
