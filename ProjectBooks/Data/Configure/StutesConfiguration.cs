using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectBooks.Data.Entities;

namespace ProjectBooks.Data.Configure
{
    public class StutesConfiguration : IEntityTypeConfiguration<Stutes>
    {
        public void Configure(EntityTypeBuilder<Stutes> builder)
        {
            builder.HasKey(x => x.ID);

            builder.Property(x => x.StutesName)
              .HasColumnType("VARCHAR")
              .HasMaxLength(100);

            builder.HasOne(x => x.User)
                .WithOne(x => x.Stutes)
                .HasForeignKey<BookUser>(x => x.StutesId)
                .IsRequired();

            builder.ToTable("Stutes");

        }
    }
}
