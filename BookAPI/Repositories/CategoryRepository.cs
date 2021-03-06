﻿using BookAPI.Models;
using System.Collections.Generic;
using System.Linq;

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
            return _categoryContext.Categories
                .Any(c => c.Id == categoryId);
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

        public bool IsDuplicateCategoryName(int categoryId, string categoryName)
        {
            var category = _categoryContext.Categories
               .Where(c => c.Id != categoryId
               && c.Name.Trim().ToUpper() == categoryName.Trim().ToUpper())
               .FirstOrDefault();

            return category != null;
        }

        public bool CreateCategory(Category category)
        {
            _categoryContext.AddAsync(category);

            return Save();
        }

        public bool UpdateCategory(Category category)
        {
            _categoryContext.Update(category);

            return Save();
        }

        public bool DeleteCategory(Category category)
        {
            _categoryContext.Remove(category);

            return Save();
        }

        public bool Save()
        {
            var saved = _categoryContext.SaveChanges();

            return saved >= 0;
        }
    }
}