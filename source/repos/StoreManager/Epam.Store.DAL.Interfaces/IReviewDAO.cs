﻿using Epam.Store.Entities;
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
        void RemoveReview(int id);
        void EditReview(int id, string newText);
        Review GetReview(int id);
        IEnumerable<Review> GetReviews(bool orderById);
    }
}