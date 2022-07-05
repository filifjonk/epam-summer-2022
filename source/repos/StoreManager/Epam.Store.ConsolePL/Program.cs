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

        private static void Delete() //дать доступ админу
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

        private static void EditProfile(string mail)
        {
            var mybll = DependencyResolver.Instance.ReviewLogic;

            Console.WriteLine("Выберите, что нужно изменить \n" +
                "1. Имя \n" +
                "2. Электронный адрес");
            int option = int.Parse(Console.ReadLine());
            
            switch (option)
            {
                case 1:
                    Console.WriteLine("Введите новое имя");

                    string newName = Console.ReadLine();

                    mybll.EditUserName(mail, newName);

                    break;

                case 2:

                    Console.WriteLine("Новый электронный адрес:");

                    string newMail = Console.ReadLine();

                    mybll.EditUserMail(mail, newMail);

                    break;

                default:

                    break;
            }
        }

        private static void Check(string log, string pas)
        {
            var bll = DependencyResolver.Instance.ReviewLogic;

            string res = bll.CheckEnter(log, pas);

            Console.WriteLine(res);

            if (res == "admin") //у администратора нет прав добавить/редактировать отзыв, возможно только удаление оценки, в случае если она нарушает политику магазина, и просмотр всех отзывов
            {
                Console.WriteLine("Выберите номер действия из списка: \n" +
                "1. Удалить отзыв \n" +
                "2. Список всех оценок \n" +
                "3. Поиск по названию магазина \n" +
                "4. Посмотреть список профилей");

                int action = int.Parse(Console.ReadLine());

                switch (action)
                {
                    case 1:

                        Delete();

                        break;

                    case 2:

                        foreach (var item in bll.GetReviews())
                        {
                            Console.WriteLine(item);
                        }

                        break;

                    case 3:

                        foreach (var item in bll.GetReviews())
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("Введите название магазина для поиска");

                        string name = Console.ReadLine();

                        foreach (var item in bll.FindByShopName(name))
                        {
                            Console.WriteLine(item);
                        }

                        break;

                    case 4:

                        foreach (var item in bll.GetUsers())
                        {
                            Console.WriteLine(item);
                        }

                        break;

                    default:

                        break;
                }
            }
            if (res == "shopper")

                {
                    Console.WriteLine("Выберите номер действия из списка: \n" +
                    "1. Добавить отзыв \n" +
                    "2. Удалить отзыв \n" +
                    "3. Редактировать отзыв \n" +
                    "4. Посмотреть все оценки \n" +
                    "5. Поиск по названию магазина \n" +
                    "6. Редактировать профиль"
                    );

                    int actionShopper = int.Parse(Console.ReadLine());

                    switch (actionShopper)
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

                        case 4:

                            foreach (var item in bll.GetReviews())
                            {
                                Console.WriteLine(item);
                            }

                            break;

                        case 5:

                        foreach (var item in bll.GetReviews())
                        {
                            Console.WriteLine(item);
                        }

                        Console.WriteLine("Введите название магазина для поиска");

                        string name = Console.ReadLine();

                        foreach (var item in bll.FindByShopName(name))
                        {
                            Console.WriteLine(item);
                        }

                        break;

                    case 6:

                        Console.WriteLine("Для того, чтобы редактировать профиль, необходимо ввести e-mail:");

                        string mail = Console.ReadLine();
                    
                        EditProfile(mail);

                        break;

                    default:

                            break;
                    }

                }
            
            if (res == "nofind")
                {
                    Console.WriteLine("Неверный логин и/или пароль");
                }
        }

        static void Main(string[] args)
        {   
            //тестовый для админа login: asd, password: qwerty
            //для покупателя login: dsa, password: ytrewq

            Console.WriteLine("Для использования приложения необходима авторизация \n" +
                "Введите логин:");

            string log = Console.ReadLine();

            Console.WriteLine("Введите пароль:");

            string pas = Console.ReadLine();

            Check(log, pas);

            //var bll = DependencyResolver.Instance.ReviewLogic;

            //foreach(var item in bll.GetReviews())
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
