using BookAPI.Models;
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

        IActionResult  CreateCategory(Category categoryToCreate, ModelStateDictionary state);

        IActionResult UpdateCategory(int categoryId, Category updatedCategoryInfo, ModelStateDictionary state);

        IActionResult DeleteCategory(int categoryId, ModelStateDictionary state);

    }
}