using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace BookAPI.Services
{
    public interface IAuthorService
    {
        IActionResult GetAuthors(ModelStateDictionary state);

        IActionResult GetAuthor(int authorId, ModelStateDictionary state);

        IActionResult GetAuthorsOfABook(int bookId, ModelStateDictionary state);

        IActionResult GetBooksByAuthor(int authorId, ModelStateDictionary state);
    }
}