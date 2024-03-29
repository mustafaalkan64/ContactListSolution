﻿using MassTransit;
using SeturContactList.Core;
using SeturContactList.Core.Entities;
using SeturContactList.Core.Events;
using SeturContactList.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturContactList.Consumer.Consumers
{
    public class ReportRequestedEventConsumer : IConsumer<ReportRequestCreatedEvent>
    {
        private readonly AppDbContext _context;

        public ReportRequestedEventConsumer(AppDbContext context)
        {
            _context = context;
        }

        public async Task Consume(ConsumeContext<ReportRequestCreatedEvent> context)
        {
            var eventModel = context.Message;
            var personContacts = _context.PersonContacts.Where(x => x.Lat == eventModel.Lat && x.Long == eventModel.Long);
            
            var personCount =  personContacts.Select(x => x.PersonId).Distinct().Count();

            var phoneCount = personContacts.Where(x => x.Phone != "").Select(x => x.PersonId).Distinct().Count();

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                var newReportDetail = new ReportDetail()
                {
                    Id = Guid.NewGuid(),
                    Lat = eventModel.Lat,
                    Long = eventModel.Long,
                    RegisteredPersonCount = personCount,
                    RegisteredPhoneCount = phoneCount,
                    ReportId = eventModel.ReportId
                };

                _context.ReportDetail.Add(newReportDetail);


                var report = _context.Reports.FirstOrDefault(x => x.Id == eventModel.ReportId);
                if(report != null)
                {
                    report.ReportStatus = ReportStatusEnum.Completed;
                }
                await _context.SaveChangesAsync();

                await dbContextTransaction.CommitAsync();
            }

        }
    }
}
