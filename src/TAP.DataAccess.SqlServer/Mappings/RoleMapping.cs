using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAP.Core.Entities;

namespace TAP.DataAccess.SqlServer.Mappings
{
    internal class RoleMapping : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Roles").HasKey(_ => _.Id);

            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.Name).HasColumnName("Name");
        }
    }
}