using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectBooks.Data.Entities;

namespace ProjectBooks.Data.Configure
{
    public class BookUserConfiguration : IEntityTypeConfiguration<BookUser>
    {
        public void Configure(EntityTypeBuilder<BookUser> builder)
        {
            builder.HasKey(x => x.Id);

            builder.ToTable("BookUser");

        }
    }
}
