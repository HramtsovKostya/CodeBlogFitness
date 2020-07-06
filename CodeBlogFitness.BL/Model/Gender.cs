using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пол пользователя.
    /// </summary>
    [Serializable]
    public class Gender
    {
        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Задать пол пользователя.
        /// </summary>
        /// <param name="name"> Название пола. </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя пола не может быть пустым или null.", nameof(name));
            }

            Name = name;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}