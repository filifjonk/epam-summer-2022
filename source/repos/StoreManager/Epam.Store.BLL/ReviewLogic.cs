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

        public void EditUserName(string mail, string newName)
        {
            _reviewDAO.EditUserName(mail, newName);
        }

        public void EditUserMail(string mail, string newMail)
        {
            _reviewDAO.EditUserMail(mail, newMail);
        }

        public string CheckEnter(string log, string pas)
        {
            _reviewDAO.CheckEnter(log, pas);
            return _reviewDAO.CheckEnter(log, pas);
        }

        public IEnumerable<Review> FindByShopName(string name) => _reviewDAO.FindByShopName(name);

        public Review GetReview(int id) => _reviewDAO.GetReview(id);

        public IEnumerable<Review> GetReviews(bool orderById = true) => _reviewDAO.GetReviews(orderById);

        public IEnumerable<User> GetUsers(bool orderById = true) => _reviewDAO.GetUsers(orderById);
    }
}
