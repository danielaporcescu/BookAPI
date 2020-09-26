using BookAPI.Models;
using System;
using System.Collections.Generic;

namespace BookAPI.Services
{
    public class BookRepository : IBookRepository
    {
        public bool BookExistsById(int bookId)
        {
            throw new NotImplementedException();
        }

        public bool BookExistsByISBN(string bookIsbn)
        {
            throw new NotImplementedException();
        }

        public Book GetBookById(int bookId)
        {
            throw new NotImplementedException();
        }

        public Book GetBookByISBN(string bookIsbn)
        {
            throw new NotImplementedException();
        }

        public decimal GetBookRating(int bookId)
        {
            throw new NotImplementedException();
        }

        public ICollection<Book> GetBooks()
        {
            throw new NotImplementedException();
        }

        public bool IsDuplicateISBN(int bookId, string bookIsbn)
        {
            throw new NotImplementedException();
        }
    }
}