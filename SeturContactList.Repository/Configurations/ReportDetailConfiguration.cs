using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SeturContactList.Core.Dtos;
using SeturContactList.Core.Entities;

namespace SeturContactList.Repository.Configurations
{
    internal class ReportDetailConfiguration : IEntityTypeConfiguration<ReportDetail>
    {
        public void Configure(EntityTypeBuilder<ReportDetail> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("Id")
                   .HasColumnType("uuid")
                   .HasDefaultValueSql("uuid_generate_v4()")    // Use 
                   .IsRequired();

            builder.Property(x => x.Lat).HasColumnType("decimal(18,2)");
            builder.Property(x => x.Long).HasColumnType("decimal(18,2)");
            builder.HasOne(x => x.Report).WithOne(x => x.ReportDetail).HasForeignKey<ReportDetail>(x => x.ReportId);
        }
    }
}
