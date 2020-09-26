using BookAPI.DTOs;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        //api/categories
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategories()
        {
            return _categoryService.GetCategories(ModelState);
        }

        //api/categories/categoryId
        [HttpGet]
        [Route("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        public IActionResult GetCategory(int categoryId)
        {
            return _categoryService.GetCategory(categoryId, ModelState);
        }

        //api/categories/books/bookId
        [HttpGet]
        [Route("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetAllCategoriesOfABook(int bookId)
        {
            return _categoryService.GetAllCategoriesOfABook(bookId, ModelState);
        }

        //api/categories/categoryId/books
        [HttpGet]
        [Route("{categoryId}/books")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public IActionResult GetBooksForCategory(int categoryId)
        {
            return _categoryService.GetBooksForCategory(categoryId, ModelState);
        }
    }
}