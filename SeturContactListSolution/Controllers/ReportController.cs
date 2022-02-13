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
        private readonly IService<ReportDetail> _reportDetailService;
        private readonly IMapper _mapper;
        private readonly IPublishEndpoint _publishEndpoint;

        public ReportController(IService<Reports> reportService, IService<ReportDetail> reportDetailService, IPublishEndpoint publishEndpoint, IMapper mapper)
        {
            _reportService = reportService;
            _reportDetailService = reportDetailService;
            _publishEndpoint = publishEndpoint;
            _mapper = mapper;
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

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var reports = await _reportService.GetAllAsync();
            var reportsDto = _mapper.Map<List<ReportDto>>(reports.ToList());
            reportsDto.ForEach(x => x.ReportStatusString = x.ReportStatus.ToString());
            return CreateActionResult(CustomResponseDto<List<ReportDto>>.Success(200, reportsDto));
        }

        [HttpGet("GetDetailByReportId/{id}")]
        public async Task<IActionResult> GetDetailByReportId(int id)
        {
            var reportDetails = _reportDetailService.Where(x => x.ReportId == id);
            var reportDetailDtos = _mapper.Map<List<ReportDetailDto>>(reportDetails.ToList());
            return CreateActionResult(CustomResponseDto<List<ReportDetailDto>>.Success(200, reportDetailDtos));
        }

    }
}
