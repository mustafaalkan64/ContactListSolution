using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeturContactList.Core.Entities;

namespace SeturContactList.Repository.Configurations
{
    internal class PersonsContactConfiguration : IEntityTypeConfiguration<PersonContacts>
    {
        public void Configure(EntityTypeBuilder<PersonContacts> builder)
        {
            builder.HasKey(x => x.Id);

            //builder.Property(x => x.Id)
            //       .HasColumnName("Id")
            //       .HasColumnType("uuid")
            //       .HasDefaultValueSql("uuid_generate_v4()")    // Use 
            //       .IsRequired();

            builder.Property(x => x.Phone).HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.City).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Town).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).HasMaxLength(500);
            builder.Property(x => x.Info).HasMaxLength(500);
            builder.Property(x => x.PersonId).IsRequired();
            builder.Property(x => x.Lat).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Long).HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Person).WithMany(x => x.PersonContacts);
                //.HasForeignKey(x => x.PersonId);

        }
    }
}
