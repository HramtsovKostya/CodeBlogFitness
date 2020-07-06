using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователей.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Список пользователей.
        /// </summary>
        private List<User> Users { get; }

        /// <summary>
        /// Текущий пользователь.
        /// </summary>
        public User CurrentUser { get; }

        /// <summary>
        /// Проверка на наличие пользователя в списке.
        /// </summary>
        public bool IsNewUser { get; } = false;

        /// <summary>
        /// Создание нового контроллера пользователей.
        /// </summary>
        /// <param name="userName"> Имя пользователя. </param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым.", nameof(userName));
            }

            Users = GetUsersData();
            CurrentUser = Users.SingleOrDefault(user => user.Name == userName);

            if (CurrentUser == null)
            {
                CurrentUser = new User(userName);
                Users.Add(CurrentUser);
                IsNewUser = true;

                SaveUsersData();
            }
        }

        /// <summary>
        /// Получение данных о новом пользователе.
        /// </summary>
        /// <param name="genderName"> Пол пользователя. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="weight"> Вес пользователя. </param>
        /// <param name="height"> Рост пользователя. </param>
        public void SetNewUserData(string genderName, DateTime birthDate, double weight = 1, double height = 1)
        {
            CurrentUser.Gender = new Gender(genderName);
            CurrentUser.BirthDate = birthDate;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

            SaveUsersData();
        }

        /// <summary>
        /// Получить сохраненный список пользователей.
        /// </summary>
        /// <returns> Список пользователей. </returns>
        public List<User> GetUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (file.Length != 0)
                {
                    return formatter.Deserialize(file) as List<User>;
                }
                else
                {
                    return new List<User>();
                }
            }
        }

        /// <summary>
        /// Сохранить список пользователей.
        /// </summary>
        public void SaveUsersData()
        {
            var formatter = new BinaryFormatter();

            using (var file = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, Users);
            }
        }
    }
}