using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult GetBookById(int bookId, ModelStateDictionary state)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult GetBookByISBN(int bookIsbn, ModelStateDictionary state)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult GetBooks(ModelStateDictionary state)
        {
            throw new System.NotImplementedException();
        }
    }
}