using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAP.Core.Entities;

namespace TAP.DataAccess.SqlServer.Mappings
{
    internal class UserMapping : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User")
                .HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.Name).HasColumnName("Name");
            builder.Property(_ => _.Password).HasColumnName("Password");
            builder.Property(_ => _.Email).HasColumnName("Email");
        }
    }
}
