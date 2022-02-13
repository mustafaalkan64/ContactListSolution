using Microsoft.EntityFrameworkCore;
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
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            modelBuilder.Entity<Persons>().HasData(new Persons()
            {
                Id = 1,
                Name = "Mustafa",
                Surname = "Alkan",
                Company = "TestCompany",
                CreatedDate = DateTime.Now
            });

            modelBuilder.Entity<Persons>().HasData(new Persons()
            {
                Id = 2,
                Name = "Ahmet",
                Surname = "Alkan",
                Company = "TestCompany1",
                CreatedDate = DateTime.Now
            });

            modelBuilder.Entity<PersonContacts>().HasData(new PersonContacts()
            {
                Id = 1,
                Address = "İzmir Çiğli",
                Email = "mustafaalkan64@gmail.com",
                PersonId = 1,
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
                Id = 2,
                Address = "İzmir Bornova",
                Email = "mustafaalkan64@gmail.com",
                PersonId = 1,
                City = "İzmir",
                Town = "Bornova",
                Info = "Test Info",
                Phone = "+905553332212",
                Lat = 35,
                Long = 28,
                CreatedDate = DateTime.Now
            },
             new PersonContacts()
             {
                 Id = 3,
                 Address = "İzmir Çiğli",
                 Email = "mustafaalkan64@gmail.com",
                 PersonId = 2,
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
                Id = 4,
                Address = "İzmir Bornova",
                Email = "mustafaalkan64@gmail.com",
                PersonId = 2,
                City = "İzmir",
                Town = "Bornova",
                Info = "Test Info",
                Phone = "+905553332212",
                Lat = 35,
                Long = 28,
                CreatedDate = DateTime.Now
            }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
