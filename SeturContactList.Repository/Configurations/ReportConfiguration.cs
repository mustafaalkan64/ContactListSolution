using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeturContactList.Core.Entities;

namespace SeturContactList.Repository.Configurations
{
    internal class ReportsConfiguration : IEntityTypeConfiguration<Reports>
    {
        public void Configure(EntityTypeBuilder<Reports> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                   .IsRequired();

            builder.Property(x => x.ReportStatus).IsRequired();
        }
    }
}
