using System;
using Epam.Reviews.Dependencies;
using Epam.Store.BLL;
using Epam.Store.Entities;
namespace Epam.Store.ConsolePL
{
    class Program
    {
        static void Main(string[] args)
        {
            var bll = DependencyResolver.Instance.ReviewLogic;

            Console.WriteLine(bll.GetReview(1)); 

            foreach(var item in bll.GetReviews())
            {
                Console.WriteLine(item);
            }
        }
    }
}
