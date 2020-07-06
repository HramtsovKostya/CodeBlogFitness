using System;
using CodeBlogFitness.BL.Controller;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Вас приветствует приложение CodeBlogFitness!");

            Console.Write("Введите имя пользователя: ");
            var userName = Console.ReadLine();
            var userController = new UserController(userName);

            if (userController.IsNewUser)
            {
                Console.Write("Введите Ваш пол: ");
                var gender = Console.ReadLine();                
                var birthDate = ParseToDateTime();
                var weight = ParseToDouble("вес");
                var height = ParseToDouble("рост");

                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.ReadLine();
        }       

        /// <summary>
        /// Преобразовать строку в тип Double.
        /// </summary>
        /// <param name="name"> Имя переменной. </param>
        /// <returns> Дробное число типа Double. </returns>
        private static double ParseToDouble(string name)
        {
            double value;
            bool isParsed;           

            do
            {
                Console.Write($"Введите {name}: ");
                isParsed = double.TryParse(Console.ReadLine(), out value);

                if (!isParsed)
                {
                    Console.WriteLine($"Неверный формат {name}а!");
                }
            }
            while (!isParsed);

            return value;
        }

        /// <summary>
        /// Преобразовать строку в дату рождения.
        /// </summary>
        /// <returns> Дата рождения. </returns>
        private static DateTime ParseToDateTime()
        {
            DateTime value;
            bool isParsed;

            do
            {
                Console.Write("Введите дату рождения (ДД.ММ.ГГГГ): ");
                isParsed = DateTime.TryParse(Console.ReadLine(), out value);

                if (!isParsed)
                {
                    Console.WriteLine("Неверный формат даты рождения!");
                }
            }
            while (!isParsed);

            return value;
        }
    }
}