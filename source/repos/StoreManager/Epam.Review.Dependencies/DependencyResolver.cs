using Epam.Reviews.BLL.Interfaces;
using Epam.Store.BLL;
using Epam.Store.DAL;
using Epam.Store.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Reviews.Dependencies
{
    public class DependencyResolver
    {
        private static DependencyResolver _instance;
        public static DependencyResolver Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new DependencyResolver();
                return _instance;
            }
        }
        public IReviewDAO ReviewDAO =>
            new ReviewSqlDAO();

        public IReviewLogic ReviewLogic =>
            new ReviewLogic(ReviewDAO);

    }
}
