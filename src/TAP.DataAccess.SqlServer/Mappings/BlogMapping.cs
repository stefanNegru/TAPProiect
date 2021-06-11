using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TAP.Core.Entities;

namespace TAP.DataAccess.SqlServer.Mappings
{
    class BlogMapping : IEntityTypeConfiguration<Blog>
    {
        public void Configure(EntityTypeBuilder<Blog> builder)
        {
            builder.ToTable("Blog")
                .HasKey(_ => _.Id);
            builder.Property(_ => _.Id).IsRequired();
            builder.Property(_ => _.Title).HasColumnName("Title");
            //builder.Property(_ => _.Author).HasColumnName("Author");
            builder.Property(_ => _.Content).HasColumnName("Content");
        }
    }
}
