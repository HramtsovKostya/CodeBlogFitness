using System;
using System.Collections.Generic;
using System.Globalization;
using CodeBlogFitness.BL.Controller;
using CodeBlogFitness.BL.Model;
using CodeBlogFitness.CMD.Languages;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        /// <summary>
        /// Точка входа в программу.
        /// </summary>
        static void Main()
        {
            Resources.Culture = CultureInfo.CreateSpecificCulture("ru-RU");

            Console.WriteLine(Resources.Greeting);
            Console.Write(Resources.EnterName);
            var userName = Console.ReadLine();

            var userController = new UserController(userName);
            var eatingController = new EatingController(userController.CurrentUser);
            var exerciseController = new ExerciseController(userController.CurrentUser);

            if (userController.IsNewUser)
            {
                Console.Write(Resources.EnterGender);
                var gender = Console.ReadLine();                
                var birthDate = ParseToDateTime(Resources.BirthDate);
                var weight = ParseToDouble(Resources.Weight);
                var height = ParseToDouble(Resources.Height);
                userController.SetNewUserData(gender, birthDate, weight, height);
            }
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine(Resources.Action);

                Console.WriteLine("E - Ввести прием пищи.");
                Console.WriteLine("A - Ввести упражнение.");
                Console.WriteLine("Q - Выйти из программы.");

                var key = Console.ReadKey();
                Console.WriteLine();

                switch (key.Key)
                {
                    case ConsoleKey.E:
                    {
                        var foods = EnterEating();
                        eatingController.Add(foods.Key, foods.Value);

                        foreach (var food in eatingController.Eating.Foods)
                        {
                            Console.WriteLine($"\t{food.Key} - {food.Value}");
                        }
                        break;
                    }

                    case ConsoleKey.A:
                    {
                        var exercise = EnterExercise();
                        exerciseController.Add(exercise.Activity, exercise.Begin, exercise.End);

                        foreach (var item in exerciseController.Exercises)
                        {
                            Console.WriteLine($"\t{item.Activity} " +
                                $"с {item.Start.ToShortTimeString()} " +
                                $"до {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    }

                    case ConsoleKey.Q:
                    {
                        Environment.Exit(0); break;
                    }
                }

                Console.ReadLine();
            }
        }

        /// <summary>
        /// Ввести новое упражнение.
        /// </summary>
        /// <returns> Физическое упражнение. </returns>
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

        /// <summary>
        /// Ввести новый прием пищи.
        /// </summary>
        /// <returns> Прием пищи. </returns>
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
        /// <returns> Переменная типа Double. </returns>
        private static double ParseToDouble(string name)
        {
            double value; bool isParsed;

            do {
                Console.Write(Resources.Enter + name + ": ");
                isParsed = double.TryParse(Console.ReadLine(), out value);

                if (!isParsed)
                {
                    Console.WriteLine(Resources.InvalidFormat + name + "!");
                }
            } while (!isParsed);

            return value;
        }

        /// <summary>
        /// Преобразовать строку в DateTime.
        /// </summary>
        /// <param name="name"> Имя переменной. </param>
        /// <returns> Переменная типа DateTime. </returns>
        private static DateTime ParseToDateTime(string name)
        {
            DateTime value; bool isParsed;

            do { 
                Console.Write(Resources.EnterField + name + Resources.DateFormat);
                isParsed = DateTime.TryParse(Console.ReadLine(), out value);

                if (!isParsed)
                {
                    Console.WriteLine(Resources.InvalidFormat + name + "!");
                }
            } while (!isParsed);

            return value;
        }
    }
}