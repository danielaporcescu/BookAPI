using BookAPI.DTOs;
using BookAPI.Models;
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
        [HttpGet("{categoryId}", Name = "GetCategory")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(CategoryDto))]
        public IActionResult GetCategory(int categoryId)
        {
            return _categoryService.GetCategory(categoryId, ModelState);
        }

        //api/categories/books/bookId
        [HttpGet("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetAllCategoriesOfABook(int bookId)
        {
            return _categoryService.GetAllCategoriesOfABook(bookId, ModelState);
        }

        //api/categories/categoryId/books
        [HttpGet("{categoryId}/books")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<BookDto>))]
        public IActionResult GetBooksForCategory(int categoryId)
        {
            return _categoryService.GetBooksForCategory(categoryId, ModelState);
        }

        //api/categories
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        [ProducesResponseType(201, Type = typeof(Category))]
        public IActionResult CreateCategory([FromBody] Category categoryToCreate)
        {
            return _categoryService.CreateCategory(categoryToCreate, ModelState);
        }


        //api/categories/categoryId
        [HttpPut("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult UpdateCategory(int categoryId, [FromBody] Category updatedCategoryInfo)
        {
            return _categoryService.UpdateCategory(categoryId, updatedCategoryInfo, ModelState);
        }

        //api/categories/categoryId
        [HttpDelete("{categoryId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(409)]
        [ProducesResponseType(422)]
        [ProducesResponseType(500)]
        public IActionResult DeleteCategory(int categoryId)
        {
            return _categoryService.DeleteCategory(categoryId, ModelState);
        }
    }
}