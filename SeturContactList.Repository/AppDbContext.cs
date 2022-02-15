using Microsoft.EntityFrameworkCore;
using SeturContactList.Core;
using SeturContactList.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SeturContactList.Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Persons> Persons { get; set; }
        public DbSet<PersonContacts> PersonContacts { get; set; }
        public DbSet<Reports> Reports { get; set; }
        public DbSet<ReportDetail> ReportDetail { get; set; }

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.Entity)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }


                    }
                }


            }


            return base.SaveChanges();
        }
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityReference)
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityReference.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                Entry(entityReference).Property(x => x.CreatedDate).IsModified = false;

                                entityReference.UpdatedDate = DateTime.Now;
                                break;
                            }


                    }
                }


            }
            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Addd the Postgres Extension for UUID generation
            modelBuilder.HasPostgresExtension("uuid-ossp");

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            Guid firstPersonId = Guid.NewGuid();
            Guid secondPersonId = Guid.NewGuid();
            Guid firstReportId = Guid.NewGuid();
            Guid secondReportId = Guid.NewGuid();

            modelBuilder.Entity<Persons>().HasData(new Persons()
            {
                Id = firstPersonId,
                Name = "Mustafa",
                Surname = "Alkan",
                Company = "TestCompany",
                CreatedDate = DateTime.Now
            });

            modelBuilder.Entity<Persons>().HasData(new Persons()
            {
                Id = secondPersonId,
                Name = "Ahmet",
                Surname = "Alkan",
                Company = "TestCompany1",
                CreatedDate = DateTime.Now
            });

            modelBuilder.Entity<PersonContacts>().HasData(new PersonContacts()
            {
                Id = Guid.NewGuid(),
                Address = "İzmir Çiğli",
                Email = "mustafaalkan64@gmail.com",
                PersonId = firstPersonId,
                City = "İzmir",
                Town = "Çiğli",
                Info = "Test Info",
                Phone = "+905553332211",
                Lat = 34,
                Long = 27,
                CreatedDate = DateTime.Now
            },
            new PersonContacts()
            {
                Id = Guid.NewGuid(),
                Address = "İzmir Bornova",
                Email = "mustafaalkan64@gmail.com",
                PersonId = firstPersonId,
                City = "İzmir",
                Town = "Bornova",
                Info = "Test Info",
                Phone = "+905553332212",
                Lat = 34,
                Long = 27,
                CreatedDate = DateTime.Now
            },
             new PersonContacts()
             {
                 Id = Guid.NewGuid(),
                 Address = "İzmir Çiğli",
                 Email = "mustafaalkan64@gmail.com",
                 PersonId = secondPersonId,
                 City = "İzmir",
                 Town = "Çiğli",
                 Info = "Test Info",
                 Phone = "+905553332211",
                 Lat = 38,
                 Long = 26,
                 CreatedDate = DateTime.Now
             },
            new PersonContacts()
            {
                Id = Guid.NewGuid(),
                Address = "İzmir Bornova",
                Email = "mustafaalkan64@gmail.com",
                PersonId = firstPersonId,
                City = "İzmir",
                Town = "Bornova",
                Info = "Test Info",
                Phone = "+905553332212",
                Lat = 38,
                Long = 26,
                CreatedDate = DateTime.Now
            }
            );

            //modelBuilder.Entity<Reports>().HasData(new Reports()
            //{
            //    Id = firstReportId,
            //    ReportStatus = ReportStatusEnum.Preparing,
            //    RequestedDate = DateTime.Now,
            //    CreatedDate = DateTime.Now
            //},
            //new Reports()
            //{
            //    Id = secondReportId,
            //    ReportStatus = ReportStatusEnum.Preparing,
            //    RequestedDate = DateTime.Now,
            //    CreatedDate = DateTime.Now
            //});


            //modelBuilder.Entity<Reports>().HasData(new ReportDetail()
            //{

            //    Id = Guid.NewGuid(),
            //    RegisteredPersonCount = 2,
            //    RegisteredPhoneCount = 2,
            //    ReportId = firstReportId,
            //    Lat = 34,
            //    Long = 27,
            //    CreatedDate = DateTime.Now
            //},
            //new ReportDetail()
            //{
            //    Id = Guid.NewGuid(),
            //    RegisteredPersonCount = 2,
            //    RegisteredPhoneCount = 2,
            //    ReportId = secondReportId,
            //    Lat = 38,
            //    Long = 26,
            //    CreatedDate = DateTime.Now
            //});

            base.OnModelCreating(modelBuilder);
        }
    }
}
