using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProjectBooks.Data.Entities;
using ProjectBooks.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace ProjectBooks.Data
{
    public class AppDbContext :IdentityDbContext
    {

        public DbSet<Customer> customers { get; set; }
        public DbSet<User> users { get; set; }

        public DbSet<Book> books { get; set; }

        public DbSet<Author> author { get; set; }

        public DbSet<Stutes> stuutes { get; set; }



        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
               base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }

}

