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
            builder.Property(x => x.Phone).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Email).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Address).IsRequired().HasMaxLength(150);
            builder.HasOne(x => x.Person).WithMany(x => x.PersonContacts).HasForeignKey(x => x.PersonId);

        }
    }
}
