using BookAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    //Tracks the relationship between project and database, knows what to delete, create etc.
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions<BookDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Review> Reviews { get; set; }
        public virtual DbSet<Reviewer> Reviewers { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
        public virtual DbSet<BookAuthor> BookAuthors { get; set; }
        public virtual DbSet<BookCategory> BookCategories { get; set; }

        // OnModelCreating is a virtual method in DbContext that we need to override
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //methods used to specify what what table and propreties
            //we are matching(established the first many to many relationships)
            modelBuilder.Entity<BookCategory>()
                // bc.BookId, bc.CategoryId - established what the keys are
                .HasKey(bc => new { bc.BookId, bc.CategoryId });

            //establishing the relationship from the point of book
            // 1. we have one book
            // 2. with many categories
            // 3. and has the foreign key of bookId
            modelBuilder.Entity<BookCategory>()
                .HasOne(b => b.Book)
                .WithMany(bc => bc.BookCategories)
                .HasForeignKey(b => b.BookId);

            // from the point of category
            modelBuilder.Entity<BookCategory>()
               .HasOne(c => c.Category)
               .WithMany(bc => bc.BookCategories)
               .HasForeignKey(c => c.CategoryId);

            //doing the same for author and books
            modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });
            modelBuilder.Entity<BookAuthor>()
                .HasOne(a => a.Author)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(a => a.AuthorId);
            modelBuilder.Entity<BookAuthor>()
                .HasOne(b => b.Book)
                .WithMany(ba => ba.BookAuthors)
                .HasForeignKey(b => b.BookId);
        }
    }
}