using System;

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
        /// Имя пользователя.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Пол пользователя.
        /// </summary>
        public Gender Gender { get; internal set; }

        /// <summary>
        /// Дата рождения.
        /// </summary>
        public DateTime BirthDate { get; internal set; }

        /// <summary>
        /// Вес пользователя.
        /// </summary>
        public double Weight { get; internal set; }

        /// <summary>
        /// Рост пользователя.
        /// </summary>
        public double Height { get; internal set; }

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
        #endregion

        /// <summary>
        /// Задать имя пользователя.
        /// </summary>
        /// <param name="name"></param>
        public User(string name) : this(name, new Gender("муж."), DateTime.Parse("01.01.1900"), 1, 1) { }

        /// <summary>
        /// Создать нового пользователя.
        /// </summary>
        /// <param name="name"> Имя пользователя. </param>
        /// <param name="gender"> Пол пользователя. </param>
        /// <param name="birthDate"> Дата рождения. </param>
        /// <param name="weight"> Вес пользователя. </param>
        /// <param name="height"> Рост пользователя. </param>
        public User(string name, Gender gender, DateTime birthDate, double weight, double height)
        {
            #region Проверка условий
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пользователя не может быть пустым или null.", nameof(name));
            }

            if (gender == null)
            {
                throw new ArgumentNullException("Пол не может быть null.", nameof(gender));
            }

            if (birthDate < DateTime.Parse("01.01.1900") || birthDate >= DateTime.Now)
            {
                throw new ArgumentException("Невозможная дата рождения.", nameof(birthDate));
            }

            if (weight <= 0)
            {
                throw new ArgumentException("Вес не может быть меньше либо равен нулю.", nameof(weight));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Рост не может быть меньше либо равен нулю.", nameof(height));
            }
            #endregion

            Name = name;
            Gender = gender;
            BirthDate = birthDate;
            Weight = weight;
            Height = height;
        }

        public override string ToString() => Name + " " + Age;
    }
}