using BookAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace BookAPI.Services
{
    public class ReviewerRepository : IReviewerRepository
    {
        private readonly BookDbContext _reviewerContext;

        //dependency injection
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
                .OrderBy(r => r.LastName)
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
            var reviewerId = _reviewerContext.Reviews
                .Where(r => r.Id == reviewId)
                .Select(er => er.Reviewer.Id)
                .FirstOrDefault();

            return _reviewerContext.Reviewers
                .Where(r => r.Id == reviewerId)
                .FirstOrDefault();
        }

        public ICollection<Review> GetReviewsByReviewer(int reviewerId)
        {
            return _reviewerContext.Reviews
                .Where(er => er.Reviewer.Id == reviewerId)
                .ToList();
        }

        public bool CreateReviewer(Reviewer reviewer)
        {
            _reviewerContext.AddAsync(reviewer);
            return Save();
        }

        public bool UpdateReviewer(Reviewer reviewer)
        {
            _reviewerContext.Update(reviewer);
            return Save();
        }

        public bool DeleteReviewer(Reviewer reviewer)
        {
            _reviewerContext.Remove(reviewer);

            return Save();
        }

        public bool Save()
        {
            var saved = _reviewerContext.SaveChanges();

            return saved >= 0;
        }
    }
}