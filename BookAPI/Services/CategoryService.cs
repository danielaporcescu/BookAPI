using BookAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace BookAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IBookRepository _bookRepository;

        public CategoryService(ICategoryRepository categoryRepository, IBookRepository bookRepository)
        {
            _categoryRepository = categoryRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult GetAllCategoriesOfABook(int bookId, ModelStateDictionary state)
        {
            if (!_bookRepository.BookExistsById(bookId))
                return new NotFoundResult();

            var categories = _categoryRepository.GetAllCategoriesOfABook(bookId);

            if (!state.IsValid)
                return new BadRequestResult();

            var categoriesDto = new List<CategoryDto>();

            foreach (var category in categories)
            {
                categoriesDto.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return new OkObjectResult(categoriesDto);
        }

        public IActionResult GetCategory(int categoryId, ModelStateDictionary state)
        {
            var category = _categoryRepository.GetCategory(categoryId);

            if (category is null)
                return new NotFoundResult();

            if (!state.IsValid)
                return new BadRequestResult();

            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };

            return new OkObjectResult(categoryDto);
        }

        public IActionResult GetCategories(ModelStateDictionary state)
        {
            var categories = _categoryRepository.GetCategories();

            if (!state.IsValid)
                return new BadRequestResult();

            var categoriesDto = new List<CategoryDto>();

            foreach (var category in categories)
            {
                categoriesDto.Add(new CategoryDto
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return new OkObjectResult(categoriesDto);
        }

        public IActionResult GetBooksForCategory(int categoryId, ModelStateDictionary state)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return new NotFoundResult();

            var books = _categoryRepository.GetBooksForCategory(categoryId);

            if (!state.IsValid)
                return new BadRequestResult();

            var booksDto = new List<BookDto>();

            foreach (var book in books)
            {
                booksDto.Add(new BookDto
                {
                    Id = book.Id,
                    Isbn = book.Isbn,
                    Title = book.Title,
                    DatePublished = book.DatePublished
                });
            }
            return new OkObjectResult(booksDto);
        }
    }
}