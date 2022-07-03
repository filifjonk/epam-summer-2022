using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Reviews.BLL.Interfaces;
using Epam.Store.DAL;
using Epam.Store.DAL.Interfaces;
using Epam.Store.Entities;
namespace Epam.Store.BLL
{
    public class ReviewLogic : IReviewLogic
    {
        private IReviewDAO _reviewDAO;

        public ReviewLogic(IReviewDAO reviewDAO)
        {
            _reviewDAO = reviewDAO;
        }

        public void AddReview(Review review)
        {
            _reviewDAO.AddReview(review);
        }

        public void RemoveReview(int id)//or guid
        {
            _reviewDAO.RemoveReview(id);
        }

        public void RemoveReview(Review review) => RemoveReview(review.ID);
        
        public void EditReview(int id, string str)
        {
            _reviewDAO.EditReview(id, str);
        }

        

        public Review GetReview(int id) => _reviewDAO.GetReview(id);

        public IEnumerable<Review> GetReviews(bool orderById = true) => _reviewDAO.GetReviews(orderById);
    }
}
