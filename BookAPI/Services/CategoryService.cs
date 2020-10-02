using BookAPI.DTOs;
using BookAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;
using System.Linq;

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

        public IActionResult CreateCategory(Category categoryToCreate, ModelStateDictionary state)
        {
            if (categoryToCreate == null)
                return new BadRequestObjectResult(state);

            var category = _categoryRepository.GetCategories()
                           .Where(c => c.Name.Trim().ToUpper() == categoryToCreate.Name.Trim().ToUpper())
                           .FirstOrDefault();
            if (category != null)
            {
                state.AddModelError("", $"Country {categoryToCreate.Name} already exists!");
                return new ObjectResult(state) { StatusCode = 422 };
            }

            if (!state.IsValid)
                return new BadRequestObjectResult(state);

            if (!_categoryRepository.CreateCategory(categoryToCreate))
            {
                state.AddModelError("", $"Something went wrong saving {categoryToCreate.Name}");
                return new ObjectResult(state) { StatusCode = 422 };
            }

            return new CreatedAtRouteResult("GetCategory", new { categoryId = categoryToCreate.Id }, categoryToCreate);
        }

        public IActionResult UpdateCategory(int categoryId, Category updatedCategoryInfo, ModelStateDictionary state)
        {
            if(updatedCategoryInfo == null)
                return new BadRequestObjectResult(state);

            if (categoryId != updatedCategoryInfo.Id)
                return new BadRequestObjectResult(state);

            if (!_categoryRepository.CategoryExists(categoryId))
                return new NotFoundObjectResult(state);

            if (_categoryRepository.IsDuplicateCategoryName(categoryId, updatedCategoryInfo.Name))
            {
                state.AddModelError("", $"Category {updatedCategoryInfo.Name} already exists!");
                return new ObjectResult(state) { StatusCode = 422 };
            }

            if (!state.IsValid)
                return new BadRequestObjectResult(state);

            if (!_categoryRepository.UpdateCategory(updatedCategoryInfo))
            {
                state.AddModelError("", $"Something went wrong updating {updatedCategoryInfo.Name}");
                return new ObjectResult(state) { StatusCode = 500 };
            }

            return new NoContentResult();

        }

        public IActionResult DeleteCategory(int categoryId, ModelStateDictionary state)
        {
            if (!_categoryRepository.CategoryExists(categoryId))
                return new NotFoundObjectResult(state);

            var categoryToDelete = _categoryRepository.GetCategory(categoryId);

            if (_categoryRepository.GetBooksForCategory(categoryId).Count() > 0)
            {
                state.AddModelError("", $"Category {categoryToDelete.Name} " +
                    "cannot be deleted because it is used by at least one Author");
                return new ObjectResult(state) { StatusCode = 409 };
            }

            if (!state.IsValid)
                return new BadRequestObjectResult(state);

            if (!_categoryRepository.DeleteCategory(categoryToDelete))
            {
                state.AddModelError("", $"Something went wrong deleting {categoryToDelete.Name}");
                return new ObjectResult(state) { StatusCode = 500 };
            }

            return new NoContentResult();

        }
    }
}