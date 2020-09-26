using BookAPI.Models;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookAPI.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly BookDbContext _bookContext;

        public BookRepository(BookDbContext bookContext)
        {
            _bookContext = bookContext;
        }

        public bool BookExistsById(int bookId)
        {
            return _bookContext.Books
                 .Any(b => b.Id == bookId);
        }

        public bool BookExistsByISBN(string bookIsbn)
        {
            return _bookContext.Books
                .Any(b => b.Isbn == bookIsbn);
        }

        public Book GetBookById(int bookId)
        {
            return _bookContext.Books
                .Where(b => b.Id == bookId)
                .FirstOrDefault();
        }

        public Book GetBookByISBN(string bookIsbn)
        {
            return _bookContext.Books
                .Where(b => b.Isbn == bookIsbn)
                .FirstOrDefault();
        }

        public decimal GetBookRating(int bookId)
        {
            var reviews = _bookContext.Reviews
                 .Where(b => b.Book.Id == bookId);

            if (reviews.Count() <= 0)
                return 0;

            var ratingAverage = ((decimal)reviews.Sum(r => r.Rating) / reviews.Count());

            return ratingAverage;
        }

        public ICollection<Book> GetBooks()
        {
            return _bookContext.Books
                 .OrderBy(b => b.Title)
                 .ToList();
        }

        public bool IsDuplicateISBN(int bookId, string bookIsbn)
        {
            var book = _bookContext.Books
                .Where(b => b.Id != bookId
                && b.Isbn.Trim().ToUpper() == bookIsbn.Trim().ToUpper())
                .FirstOrDefault();

            return book != null;
        }
    }
}