using BookAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;

namespace BookAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;

        public AuthorService(IAuthorRepository authorRepository, IBookRepository bookRepository)
        {
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
        }

        public IActionResult GetAuthor(int authorId, ModelStateDictionary state)
        {
            var author = _authorRepository.GetAuthor(authorId);

            if (author is null)
                return new NotFoundResult();

            if (!state.IsValid)
                return new BadRequestResult();

            var authorDto = new AuthorDto()
            {
                Id = author.Id,
                FirstName = author.FirstName,
                LastName = author.LastName
            };

            return new OkObjectResult(authorDto);
        }

        public IActionResult GetAuthors(ModelStateDictionary state)
        {
            var authors = _authorRepository.GetAuthors();

            if (!state.IsValid)
                return new BadRequestResult();

            var authorsDto = new List<AuthorDto>();

            foreach (var author in authors)
            {
                authorsDto.Add(new AuthorDto
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName
                });
            }
            return new OkObjectResult(authorsDto);
        }

        public IActionResult GetAuthorsOfABook(int bookId, ModelStateDictionary state)
        {
            if (_bookRepository.BookExistsById(bookId))
                return new NotFoundResult();

            var authors = _authorRepository.GetAuthorsOfABook(bookId);

            if (!state.IsValid)
                return new BadRequestResult();

            var authorsDto = new List<AuthorDto>();

            foreach (var author in authors)
            {
                authorsDto.Add(new AuthorDto
                {
                    Id = author.Id,
                    FirstName = author.FirstName,
                    LastName = author.LastName
                });
            }
            return new OkObjectResult(authorsDto);
        }

        public IActionResult GetBooksByAuthor(int authorId, ModelStateDictionary state)
        {
            if (!_authorRepository.AuthorExists(authorId))
                return new NotFoundResult();

            var books = _authorRepository.GetBooksByAuthor(authorId);

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