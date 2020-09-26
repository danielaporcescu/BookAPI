using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookAPI.Services
{
    public interface ICategoryService
    {
        IActionResult GetCategories(ModelStateDictionary state);

        IActionResult GetCategory(int categoryId, ModelStateDictionary state);

        IActionResult GetAllCategoriesOfABook(int bookId, ModelStateDictionary state);

        IActionResult GetBooksForCategory(int categoryId, ModelStateDictionary state);
    }
}