using System;
using CodeBlogFitness.BL.Controller;

namespace CodeBlogFitness.CMD
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Вас приветствует приложение CodeBlogFitness!");
            
            Console.WriteLine("Введите имя пользователя:");
            var name = Console.ReadLine();

            Console.WriteLine("Введите Ваш пол:");
            var gender = Console.ReadLine();

            Console.WriteLine("Введите дату рождения:");
            var birthDate = DateTime.Parse(Console.ReadLine());

            Console.WriteLine("Введите Ваш вес:");
            var weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Введите Ваш рост:");
            var height = double.Parse(Console.ReadLine());

            var userController = new UserController(name, gender, birthDate, weight, height);
            userController.Save();

            Console.ReadLine();
        }
    }
}