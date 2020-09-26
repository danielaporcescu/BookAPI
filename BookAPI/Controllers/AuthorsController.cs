using BookAPI.DTOs;
using BookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : Controller
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        //api/authors
        [HttpGet]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        public IActionResult GetAuthors()
        {
            return _authorService.GetAuthors(ModelState);
        }

        //api/authors/authorId
        [HttpGet]
        [Route("{authorId}")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(AuthorDto))]
        public IActionResult GetAuthor(int authorId)
        {
            return _authorService.GetAuthor(authorId, ModelState);
        }

        //api/authors/authorId
        [HttpGet]
        [Route("{bookId}/authors")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        public IActionResult GetAuthorsOfABook(int bookId)
        {
            return _authorService.GetAuthorsOfABook(bookId, ModelState);
        }

        //api/authors/authorId
        [HttpGet]
        [Route("{authorId}/books")]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(IEnumerable<AuthorDto>))]
        public IActionResult GetBooksByAuthor(int authorId)
        {
            return _authorService.GetBooksByAuthor(authorId, ModelState);
        }
    }
}