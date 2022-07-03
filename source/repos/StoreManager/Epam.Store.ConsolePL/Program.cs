using System;
using Epam.Reviews.Dependencies;
using Epam.Store.BLL;
using Epam.Store.Entities;
namespace Epam.Store.ConsolePL
{
    class Program
    {
        private static void Add()
        {
            Review review = new Review();

            Console.WriteLine("Введите название магазина");

            review.Shop_name = Console.ReadLine();

            Console.WriteLine("Ваш отзыв о работе магазина");

            review.Text = Console.ReadLine();

            review.CreationDate = DateTime.Now;

            var bll = DependencyResolver.Instance.ReviewLogic;

            bll.AddReview(review);
        }

        private static void Delete() //дать доступ только админу
        {
            var bll = DependencyResolver.Instance.ReviewLogic;

            foreach (var item in bll.GetReviews())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Номер отзыва для удаления");

            int id = int.Parse(Console.ReadLine());

            bll.RemoveReview(id);

        }

        private static void Edit()
        {
            var bll = DependencyResolver.Instance.ReviewLogic;

            foreach (var item in bll.GetReviews())
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("Номер отзыва для редактирования:");

            int id = int.Parse(Console.ReadLine());

            Console.WriteLine("Измененная оценка:");

            string str = Console.ReadLine();

            bll.EditReview(id, str);

        }

        static void Main(string[] args)
        {

            Console.WriteLine("Выберите номер действия из списка: \n" +
                "1. Добавить отзыв \n" +
                "2. Удалить отзыв \n" +
                "3. Редактировать отзыв \n");

            int action = int.Parse(Console.ReadLine());

            switch (action)
            {
                case 1:

                    Add();
                    break;

                case 2:

                    Delete();
                    break;

                case 3:

                    Edit();
                    break;

            }




            var bll = DependencyResolver.Instance.ReviewLogic;

            foreach(var item in bll.GetReviews())
            {
                Console.WriteLine(item);
            }
        }
    }
}
