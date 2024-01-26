using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ProjectBooks.Data.Entities;

namespace ProjectBooks.Data.Configure
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x=>x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.UserName)
                .HasColumnType("VARCHAR")
                .HasMaxLength(128);

            builder.Property(x => x.Address)
                .HasColumnType("VARCHAR")
                .HasMaxLength(20);

            builder.Property(x => x.Password)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.CheckPassword)
                .HasColumnType("VARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .HasColumnType("VARCHAR")
                .HasMaxLength(128);

            builder.Property(x => x.Phone)
                .HasColumnType("VARCHAR")
                .HasMaxLength(10);

            builder.ToTable("User");
        }
    }
}
