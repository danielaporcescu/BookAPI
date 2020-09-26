using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookAPI.Services
{
    public class BookService : IBookService
    {
        public IActionResult GetBookById(ModelStateDictionary state)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult GetBookByISBN(ModelStateDictionary state)
        {
            throw new System.NotImplementedException();
        }

        public IActionResult GetBooks(ModelStateDictionary state)
        {
            throw new System.NotImplementedException();
        }
    }
}