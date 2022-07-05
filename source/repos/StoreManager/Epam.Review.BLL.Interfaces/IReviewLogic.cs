using System;
using Epam.Store.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Reviews.BLL.Interfaces
{
    public interface IReviewLogic
    {
        void AddReview(Review review);

        void RemoveReview(int id);

        void RemoveReview(Review review);

        void EditReview(int id, string newText);

        void EditUserName(string mail, string newName);

        void EditUserMail(string mail, string newMail);

        string CheckEnter(string log, string pas);

        Review GetReview(int id);

        IEnumerable<Review> GetReviews(bool orderById = true);

        IEnumerable<Review> FindByShopName(string name);

        IEnumerable<User> GetUsers(bool orderById = true);
    }
}
