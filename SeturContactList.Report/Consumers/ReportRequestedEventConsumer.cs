using MassTransit;
using SeturContactList.Core;
using SeturContactList.Core.Entities;
using SeturContactList.Core.Events;
using SeturContactList.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SeturContactList.Report.Consumers
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
            var personCount = _context.PersonContacts.Where(x => x.Lat == eventModel.Lat && x.Long == eventModel.Long)
                                                     .Select(x => x.PersonId).Distinct()
                                                     .ToList()
                                                     .Count();

            var phoneCount = _context.PersonContacts.Where(x => x.Lat == eventModel.Lat && x.Long == eventModel.Long && x.Phone != "")
                                                     .Select(x => x.PersonId).Distinct()
                                                     .ToList()
                                                     .Count();

            using (var dbContextTransaction = _context.Database.BeginTransaction())
            {
                _context.ReportDetail.Add(new ReportDetail()
                {
                    Lat = eventModel.Lat,
                    Long = eventModel.Long,
                    RegisteredPersonCount = personCount,
                    RegisteredPhoneCount = phoneCount,
                    ReportId = eventModel.ReportId
                });


                var report = _context.Reports.FirstOrDefault(x => x.Id == eventModel.ReportId);
                if(report != null)
                {
                    report.ReportStatus = (int)ReportStatusEnum.Completed;
                }
                await _context.SaveChangesAsync();

                await dbContextTransaction.CommitAsync();
            }

        }
    }
}
