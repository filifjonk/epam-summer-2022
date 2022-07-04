using Epam.Store.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Store.DAL.Interfaces
{
    public interface IReviewDAO
    {
        bool AddReview(Review review);
        bool RemoveReview(int id);
        bool EditReview(int id, string newText);
        string CheckEnter(string log, string pas);
        Review GetReview(int id);
        IEnumerable<Review> GetReviews(bool orderById);
        IEnumerable<Review> FindByShopName(string name);
    }
}
