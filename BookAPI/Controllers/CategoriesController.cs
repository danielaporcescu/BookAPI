using BookAPI.DTOs;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    public class CategoriesController : Controller
    {
        private ICategoryRepository _categoryRepository;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        //api/categories
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategories()
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var categories = _categoryRepository.GetCategories();

            var categoriesDto = new List<CategoryDto>();

            foreach (var category in categories)
            {
                categoriesDto.Add(new CategoryDto()
                {
                    Id = category.Id,
                    Name = category.Name
                });
            }
            return Ok(categoriesDto);
        }

        //api/categories
        [HttpGet]
        [Route("{categoryId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategory(int categoryId)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var category = _categoryRepository.GetCategory(categoryId);

            if (!_categoryRepository.CategoryExists(categoryId))
                return NotFound();

            var categoryDto = new CategoryDto()
            {
                Id = category.Id,
                Name = category.Name
            };

            return Ok(categoryDto);
        }

        //api/categories
        [HttpGet]
        [Route("books/{bookId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<CategoryDto>))]
        public IActionResult GetCategoryOfABook(int bookId)
        {
            //TO-DO - VALIDATE THAT BOOK EXISTS
            if (!ModelState.IsValid)
                return BadRequest();

            var book = _categoryRepository.GetCategoryOfABook(bookId);

            var categoryDto = new CategoryDto()
            {
                Id = book.Id,
                Name = book.Name
            };

            return Ok(categoryDto);
        }
    }
}