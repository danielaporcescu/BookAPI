using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public interface IBookRepository
    {
        ICollection<Book> GetBooks();

        Book GetBookById(int bookId);

        Book GetBookByISBN(string bookIsbn);

        bool BookExistsById(int bookId);

        bool BookExistsByISBN(string bookIsbn);

        bool IsDuplicateISBN(int bookId, string bookIsbn);

        decimal GetBookRating(int bookId);
    }
}