using BookAPI.Models;
using System.Collections.Generic;

namespace BookAPI.Services
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int categoryId);

        ICollection<Category> GetAllCategoriesOfABook(int bookId);

        ICollection<Book> GetBooksForCategory(int categoryId);

        bool CategoryExists(int categoryId);

        bool IsDuplicateCategoryName(int categoryId, string categoryName);

        bool CreateCategory(Category category);

        bool UpdateCategory(Category category);

        bool DeleteCategory(Category category);

        bool Save();
    }
}