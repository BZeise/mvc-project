using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using mvc_project.Models;

namespace mvc_project.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Book>().HasData(
                new Book { BookId = 1, Author = "Frank Herbert", Title = "Dune", DisplayOrder = 14 },
                new Book { BookId = 2, Author = "Frank Herbert", Title = "Dune Messiah", DisplayOrder = 15 },
                new Book { BookId = 3, Author = "Frank Herbert", Title = "Children of Dune", DisplayOrder = 16 }
            );
        }
    }
}