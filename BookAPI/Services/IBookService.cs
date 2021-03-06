﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BookAPI.Services
{
    public interface IBookService
    {
        IActionResult GetBooks(ModelStateDictionary state);

        IActionResult GetBookById(int bookId, ModelStateDictionary state);

        IActionResult GetBookByISBN(string bookIsbn, ModelStateDictionary state);

        IActionResult GetBookRating(int bookId, ModelStateDictionary state);
    }
}