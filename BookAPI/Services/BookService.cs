using BookAPI.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Collections.Generic;

namespace BookAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IActionResult GetBookById(int bookId, ModelStateDictionary state)
        {
            var book = _bookRepository.GetBookById(bookId);

            if (book is null)
                return new NotFoundResult();

            if (!state.IsValid)
                return new BadRequestResult();

            var bookDto = new BookDto()
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                DatePublished = book.DatePublished
            };

            return new OkObjectResult(bookDto);
        }

        public IActionResult GetBookByISBN(string bookIsbn, ModelStateDictionary state)
        {
            var book = _bookRepository.GetBookByISBN(bookIsbn);

            if (book is null)
                return new NotFoundResult();

            if (!state.IsValid)
                return new BadRequestResult();

            var bookDto = new BookDto()
            {
                Id = book.Id,
                Isbn = book.Isbn,
                Title = book.Title,
                DatePublished = book.DatePublished
            };

            return new OkObjectResult(bookDto);
        }

        public IActionResult GetBookRating(int bookId, ModelStateDictionary state)
        {
            var rating = _bookRepository.GetBookRating(bookId);

            if (rating == 0)
                return new NotFoundResult();

            if (!state.IsValid)
                return new BadRequestResult();

            return new OkObjectResult(rating);
        }

        public IActionResult GetBooks(ModelStateDictionary state)
        {
            var books = _bookRepository.GetBooks();

            if (!state.IsValid)
                return new BadRequestResult();

            var booksDto = new List<BookDto>();

            foreach (var book in books)
            {
                booksDto.Add(new BookDto()
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