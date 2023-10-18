using Microsoft.EntityFrameworkCore;
using ModelClassLibrary.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelClassLibrary.Infra
{
    public class AppDbContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData( new Author { AuthorId=1, Name="Robin Sharma"});
            modelBuilder.Entity<Category>().HasData(new Category {CategoryId=1, Name="Self Development"  });
            modelBuilder.Entity<Book>().HasData( new Book { BookId=1, Title="book1", AuthorId=1,CategoryId=1 } );
        }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Author { get; set; }

        public DbSet<Category> Category { get; set; }

    }
}
