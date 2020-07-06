using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер пользователя.
    /// </summary>
    public class UserController
    {
        /// <summary>
        /// Пользователь приложения.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Создание нового контроллера пользователя.
        /// </summary>
        /// <param name="userName"> Имя пользователя. </param>
        /// <param name="genderName"> Пол пользователя. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="weight"> Вес пользователя. </param>
        /// <param name="height"> Рост пользователя. </param>
        public UserController(string userName, string genderName, DateTime birthDate, double weight, double height)
        {
            User = new User(userName, new Gender(genderName), birthDate, weight, height);
        }

        /// <summary>
        /// Получить данные пользователя.
        /// </summary>
        /// <returns> Пользователь приложения. </returns>
        public UserController()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                {
                    User = user;
                }
            }
        }        

        /// <summary>
        /// Сохранить данные пользователя.
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();

            using (var fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, User);
            }
        }        
    }
}