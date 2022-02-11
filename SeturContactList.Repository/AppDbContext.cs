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
                UUID = Guid.NewGuid(),
                Name = "Mustafa",
                Surname = "Alkan",
                Company = "TestCompany",
                CreatedDate = DateTime.Now,
                PersonContacts = new List<PersonContacts>()
                {
                    new PersonContacts() { Id = 1,
                        Address = "İzmir Çiğli",
                        Email = "mustafaalkan64@gmail.com",
                        PersonId = 1,
                        City = "İzmir",
                        Info = "Test Info",
                        Phone = "+905553332211",
                        CreatedDate = DateTime.Now}
                }
            }

            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
