using BookAPI.Models;
using System.Collections.Generic;

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