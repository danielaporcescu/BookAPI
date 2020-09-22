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

        Category GetCategoryOfABook(int bookId);

        ICollection<Book> GetBooksForCategoty(int categotyId);

        bool CategoryExists(int categoryId);
    }
}