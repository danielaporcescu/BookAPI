﻿using BookAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookAPI.Services
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookDbContext _reviewContext;

        public ReviewRepository(BookDbContext reviewContext)
        {
            _reviewContext = reviewContext;
        }

        public ICollection<Review> GetReviews()
        {
            return _reviewContext.Reviews
                .OrderBy(r => r.Rating)
                .ToList();
        }

        public Review GetReview(int reviewId)
        {
            return _reviewContext.Reviews
                .Where(r => r.Id == reviewId)
                .FirstOrDefault();
        }

        public ICollection<Review> GetReviewsOfABook(int bookId)
        {
            return _reviewContext.Reviews
                .Where(b => b.Book.Id == bookId)
                .ToList();
        }

        public Book GetBookOfAReview(int reviewId)
        {
            var bookId = _reviewContext.Reviews
                .Where(r => r.Id == reviewId)
                .Select(b => b.Book.Id)
                .FirstOrDefault();
            return _reviewContext.Books
                .Where(b => b.Id == bookId)
                .FirstOrDefault();
        }

        public bool ReviewExists(int reviewId)
        {
            return _reviewContext.Reviews
                .Any(r => r.Id == reviewId);
        }

        public bool CreateReview(Review review)
        {
            _reviewContext.AddAsync(review);
            return Save();
        }

        public bool UpdateReview(Review review)
        {
            _reviewContext.Update(review);

            return Save();
        }

        public bool DeleteReview(Review review)
        {
            _reviewContext.Remove(review);
            return Save();
        }

        public bool Save()
        {
            var saved = _reviewContext.SaveChanges();

            return saved >= 0;
        }
    }
}