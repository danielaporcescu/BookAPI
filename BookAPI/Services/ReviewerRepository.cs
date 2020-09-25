using BookAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookAPI.Services
{
    public class ReviewerRepository : IReviewerRepository
    {
        private BookDbContext _reviewerContext;

        public ReviewerRepository(BookDbContext reviewerContext)
        {
            _reviewerContext = reviewerContext;
        }

        public bool ReviewerExists(int reviewerId)
        {
            return _reviewerContext.Reviewers.Any(r => r.Id == reviewerId);
        }

        public ICollection<Reviewer> GetReviewers()
        {
            return _reviewerContext.Reviewers
                .OrderBy(r => r.FirstName)
                .ToList();
        }

        public Reviewer GetReviewer(int reviewerId)
        {
            return _reviewerContext.Reviewers
                .Where(r => r.Id == reviewerId)
                .FirstOrDefault();
        }

        public Reviewer GetReviewerOfAReview(int reviewId)
        {
            return _reviewerContext.Reviews
                .Where(r => r.Id == reviewId)
                .Select(er => er.Reviewer)
                .FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _reviewerContext.Reviews
                .Where(er => er.Reviewer.Id == reviewerId)
                .ToList();
        }
    }
}