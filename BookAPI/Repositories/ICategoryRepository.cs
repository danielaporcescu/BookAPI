using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public interface ICategoryRepository
    {
        ICollection<Category> GetCategories();

        Category GetCategory(int categoryId);

        ICollection<Category> GetAllCategoriesOfABook(int bookId);

        ICollection<Book> GetBooksForCategory(int categoryId);

        bool CategoryExists(int categoryId);
    }
}