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
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(resManager.GetString("EnterGender", culture));
                var gender = Console.ReadLine();                
                var birthDate = ParseToDateTime(resManager.GetString("BirthDate", culture));
                var weight = ParseToDouble(resManager.GetString("Weight", culture));
                var height = ParseToDouble(resManager.GetString("Height", culture));
                userController.SetNewUserData(gender, birthDate, weight, height);
            }

            Console.WriteLine(userController.CurrentUser);
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");

                Console.WriteLine("E - ввести прием пищи");
                Console.WriteLine("A - ввести упражнение");
                Console.WriteLine("Q - выход");

                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                        var foods = EnterEating();
                        eatingController.Add(foods.Key, foods.Value);

                        foreach (var food in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{food.Key} - {food.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var exercise = EnterExercise();
                        exerciseController.Add(exercise.Activity, exercise.Begin, exercise.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} " +
                                $"с {item.Start.ToShortTimeString()} до {item.Finish.ToShortTimeString()}");
                        }
                        break;

                    case ConsoleKey.Q:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
        }

        private static (DateTime Begin, DateTime End, Activity Activity) EnterExercise()
        {
            Console.Write("Введите название упражнения: ");
            var name = Console.ReadLine();

            var energy = ParseToDouble("расход энергии в минуту");
            var activity = new Activity(name, energy);

            var begin = ParseToDateTime("начало упражнения");
            var end = ParseToDateTime("конец упражнения");

            return (begin, end, activity);
        }

        private static KeyValuePair<Food, double> EnterEating()
        {
            Console.Write("Введите название продукта: ");
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
        private static DateTime ParseToDateTime(string name)
        {
            DateTime value;
            bool isParsed;

            do
            {
                Console.Write($"Введите поле {name} (ДД.ММ.ГГГГ): ");
                isParsed = DateTime.TryParse(Console.ReadLine(), out value);

                if (!isParsed)
                {
                    Console.WriteLine($"Неверный формат поля {name}!");
                }
            }
            while (!isParsed);

            return value;
        }
    }
}