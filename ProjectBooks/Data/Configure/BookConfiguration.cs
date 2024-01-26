using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectBooks.Data.Entities;

namespace ProjectBooks.Data.Configure
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {

            builder.HasKey(x => x.ID);
            builder.Property(x => x.ID).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);


            builder.Property(x => x.Description)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.HasOne(x => x.author)
                .WithMany(x => x.Books)
                .HasForeignKey(x => x.AuthorID)
                .IsRequired();

            builder.HasMany(x => x.users)
                .WithMany(x => x.books)
                .UsingEntity<BookUserConfiguration>();


            builder.ToTable("Book");
        }
    }
}
