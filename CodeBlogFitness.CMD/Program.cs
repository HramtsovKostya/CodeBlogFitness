using System;
using System.Collections.Generic;
using System.Globalization;
using System.Resources;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main()
        {
            var culture = CultureInfo.CreateSpecificCulture("ru-RU");
            var resManager = new ResourceManager
                ("CodeBlogFitness.CMD.Languages.Messages", typeof(Program).Assembly);

            Console.WriteLine(resManager.GetString("Greeting", culture));

            Console.Write(resManager.GetString("EnterName", culture));
            var userName = Console.ReadLine();

            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();                
                var birthDate = ParseToDateTime();
                var weight = ParseToDouble(resManager.GetString("Weight", culture));
                var height = ParseToDouble(resManager.GetString("Height", culture));

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