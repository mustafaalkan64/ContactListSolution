using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeturContactList.Core.Entities;

namespace SeturContactList.Repository.Configurations
{
    internal class PersonsConfiguration : IEntityTypeConfiguration<Persons>
    {
        public void Configure(EntityTypeBuilder<Persons> builder)
        {
            //builder.HasKey(x => x.Id);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                   .IsRequired();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Surname).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Company).IsRequired().HasMaxLength(150);

        }
    }
}
