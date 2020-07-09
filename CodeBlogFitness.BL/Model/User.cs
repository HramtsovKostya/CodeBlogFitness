using System;
using System.Collections.Generic;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пользователь.
    /// </summary>
    [Serializable]
    public class User
    {
        #region Свойства
        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор пола пользователя.
        /// </summary>
        public int? GenderId { get; set; }

        /// <summary>
        /// Имя пользователя.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public virtual Gender Gender { get; set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Рост пользователя.
        /// </summary>
        public double Height { get; set; }

        /// <summary>
        /// Возраст пользователя.
        /// </summary>
        public int Age
        {
            get
            {
                int age = DateTime.Today.Year - BirthDate.Year;
                return BirthDate > DateTime.Today.AddYears(-age) ? --age : age;
            }
        }

        /// <summary>
        /// Коллекция приемов пищи.
        /// </summary>
        public virtual ICollection<Eating> Eatings { get; set; }

        /// <summary>
        /// Коллекция упражнений пользователя.
        /// </summary>
        public virtual ICollection<Exercise> Exercises { get; set; }
        #endregion

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        public User() { }

        /// <summary>
        /// Задать имя пользователя.
        /// </summary>
        /// <param name="name"></param>
        public User(string name) : this(name, new Gender("муж."),
            DateTime.Parse("01.01.1900"), 1, 1) { }

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя пользователя. </param>
        /// <param name="gender"> Пол пользователя. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="weight"> Вес пользователя. </param>
        /// <param name="height"> Рост пользователя. </param>
        public User(string name,
                    Gender gender,
                    DateTime birthDate,
                    double weight,
                    double height)
        {
            #region Проверка ограничений
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException
                    ("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException
                    ("Пол не может быть null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException
                    ("Невозможная дата рождения.", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException
                    ("Вес не может быть меньше либо равен нулю.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException
                    ("Рост не может быть меньше либо равен нулю.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        /// <summary>
        /// Преобразование в строковый тип.
        /// </summary>
        /// <returns> Имя и возраст пользователя. </returns>
        public override string ToString() => Name + " " + Age;
    }
}