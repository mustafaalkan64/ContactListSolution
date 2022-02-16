using Microsoft.EntityFrameworkCore;
using SeturContactList.Core.Entities;
using SeturContactList.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeturContactList.UnitTest
{
    public class InitialDbContextOptions
    {
        protected DbContextOptions<AppDbContext> _contextOptions { get; private set; }

        public void SetContextOptions(DbContextOptions<AppDbContext> contextOptions)
        {
            _contextOptions = contextOptions;
            Seed();
        }

        public void Seed()
        {
            using (AppDbContext context = new AppDbContext(_contextOptions))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                var report1Id = Guid.NewGuid();
                var report2Id = Guid.NewGuid();
                var report3Id = Guid.NewGuid();

                context.Reports.Add(new Reports { Id = report1Id, CreatedDate = DateTime.Now, ReportStatus = Core.ReportStatusEnum.Preparing, RequestedDate = DateTime.Now });
                context.Reports.Add(new Reports { Id = report2Id, CreatedDate = DateTime.Now, ReportStatus = Core.ReportStatusEnum.Preparing, RequestedDate = DateTime.Now });
                context.Reports.Add(new Reports { Id = report3Id, CreatedDate = DateTime.Now, ReportStatus = Core.ReportStatusEnum.Preparing, RequestedDate = DateTime.Now });
                context.SaveChanges();

                context.ReportDetail.Add(new ReportDetail() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, Lat = 35, Long = 27, RegisteredPersonCount = 3, RegisteredPhoneCount = 3, ReportId = report1Id });
                context.ReportDetail.Add(new ReportDetail() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, Lat = 35, Long = 24, RegisteredPersonCount = 2, RegisteredPhoneCount = 2, ReportId = report2Id });
                context.ReportDetail.Add(new ReportDetail() { Id = Guid.NewGuid(), CreatedDate = DateTime.Now, Lat = 42, Long = 28, RegisteredPersonCount = 3, RegisteredPhoneCount = 4, ReportId = report3Id });

                context.SaveChanges();
            }
        }
    }
}
