using System;
using System.Collections.Generic;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

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
            var eatingController = new EatingController(userController.CurrentUser);

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
            Console.WriteLine();

            Console.WriteLine("Что вы хотите сделать?");

            Console.WriteLine("E - ввести прием пищи");
            var key = Console.ReadKey();

            if (key.Key == ConsoleKey.E)
            {
                var foods = EnterEating();
                eatingController.Add(foods.Key, foods.Value);

                foreach (var food in eatingController.Eating.Foods)
                {
                    Console.WriteLine($"\t{food.Key} - {food.Value}");
                }
            }

            Console.ReadLine();
        }

        private static KeyValuePair<Food, double> EnterEating()
        {
            Console.Write("\nВведите название продукта: ");
            var foodName = Console.ReadLine();

            var calories = ParseToDouble("калорийность");
            var proteins = ParseToDouble("количество белков");
            var fats = ParseToDouble("количество жиров");
            var carbohydrates = ParseToDouble("количество углеводов");
            
            var weight = ParseToDouble("вес порции");
            var product = new Food(foodName, calories, proteins, fats, carbohydrates);
            
            return new KeyValuePair<Food, double>(product, weight);
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
                    Console.WriteLine($"Неверный формат поля {name}!");
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