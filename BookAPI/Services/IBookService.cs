using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookAPI.Services
{
    public interface IBookService
    {
        IActionResult GetBooks(ModelStateDictionary state);

        IActionResult GetBookById(ModelStateDictionary state);

        IActionResult GetBookByISBN(ModelStateDictionary state);
    }
}