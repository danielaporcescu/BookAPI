using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly BookDbContext _categoryContext;

        public CategoryRepository(BookDbContext categoryContext)
        {
            _categoryContext = categoryContext;
        }

        public bool CategoryExists(int categoryId)
        {
            return _categoryContext.Categories.Any(c => c.Id == categoryId);
        }

        public ICollection<Book> GetBooksForCategory(int categotyId)
        {
            return _categoryContext.BookCategories
                 .Where(c => c.CategoryId == categotyId)
                 .Select(b => b.Book)
                 .ToList();
        }

        public ICollection<Category> GetCategories()
        {
            return _categoryContext.Categories
                .OrderBy(c => c.Name)
                .ToList();
        }

        public ICollection<Category> GetAllCategoriesOfABook(int bookId)
        {
            return _categoryContext.BookCategories
               .Where(b => b.Book.Id == bookId)
               .Select(c => c.Category)
               .ToList();
        }

        public Category GetCategory(int categoryId)
        {
            return _categoryContext.Categories
                .Where(c => c.Id == categoryId)
                .FirstOrDefault();
        }
    }
}