using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CRUDWebApp.Models;

namespace CRUDWebApp.Data
{
    public class CRUDWebAppContext : DbContext
    {
        public CRUDWebAppContext (DbContextOptions<CRUDWebAppContext> options)
            : base(options)
        {
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().ToTable("Author");
            modelBuilder.Entity<Book>().ToTable("Book");
        }
    }
}
