﻿using BookAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookAPI.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly BookDbContext _authorContext;

        public AuthorRepository(BookDbContext authorContext)
        {
            _authorContext = authorContext;
        }

        public bool AuthorExists(int authorId)
        {
            return _authorContext.Authors
                .Any(a => a.Id == authorId);
        }

        public Author GetAuthor(int authorId)
        {
            return _authorContext.Authors
                .Where(a => a.Id == authorId)
                .FirstOrDefault();
        }

        public ICollection<Author> GetAuthors()
        {
            return _authorContext.Authors
                .OrderBy(a => a.LastName)
                .ToList();
        }

        public ICollection<Author> GetAuthorsOfABook(int bookId)
        {
            return _authorContext.BookAuthors
                .Where(b => b.BookId == bookId)
                .Select(a => a.Author)
                .ToList();
        }

        public ICollection<Book> GetBooksByAuthor(int authorId)
        {
            return _authorContext.BookAuthors
                .Where(a => a.AuthorId == authorId)
                .Select(b => b.Book)
                .ToList();
        }
    }
}