using MassTransit;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Moq;
using SeturContactList.Consumer.Consumers;
using SeturContactList.Core.Events;
using SeturContactList.Repository;
using System.Threading.Tasks;
using Xunit;

namespace SeturContactList.UnitTest
{
    public class ReportConsumeTestWithInMemory : InitialDbContextOptions
    {
        private readonly AppDbContext _dbContext;
        private readonly ReportRequestedEventConsumer _reportRequestedEventConsumer;


        public ReportConsumeTestWithInMemory()
        {
            SetContextOptions(new DbContextOptionsBuilder<AppDbContext>().UseInMemoryDatabase("UdemyUnitTestInMemoryDB")
                .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options);

            _dbContext = new AppDbContext(_contextOptions);
            _reportRequestedEventConsumer = new ReportRequestedEventConsumer(_dbContext);
        }


        [Fact]
        public async Task Ensure_ReportDetailCreated_Properly_With_Consume()
        {
            //Arrange
            var report = await _dbContext.Reports.FirstAsync();
            var reportRequestCreatedEvent = new ReportRequestCreatedEvent
            {
                ReportId = report.Id,
                Lat = 35, 
                Long = 27
            };
            //Mock the context
            var context = Mock.Of<ConsumeContext<ReportRequestCreatedEvent>>(_ =>
                _.Message == reportRequestCreatedEvent);

            //Act
            await _reportRequestedEventConsumer.Consume(context);
            var reportDetail = await _dbContext.ReportDetail.LastOrDefaultAsync(x => x.ReportId == report.Id);

            //Assert
            Assert.Equal(Core.ReportStatusEnum.Completed, report.ReportStatus);
            Assert.Equal(3, reportDetail.RegisteredPersonCount);
            Assert.Equal(2, reportDetail.RegisteredPhoneCount);
        }

    }
}
