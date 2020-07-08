using System;
using System.Collections.Generic;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Пол пользователя.
    /// </summary>
    [Serializable]
    public class Gender
    {
        #region Свойства
        /// <summary>
        /// Идентификатор пола пользователя.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название пола.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Коллекция пользователей.
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
        #endregion

        /// <summary>
        /// Задать пол пользователя.
        /// </summary>
        public Gender() { }

        /// <summary>
        /// Задать пол пользователя.
        /// </summary>
        /// <param name="name"> Название пола. </param>
        public Gender(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException
                    ("Имя пола не может быть пустым или null.", nameof(name));
            }

            Name = name;
        }

        /// <summary>
        /// Преобразование в строковый тип.
        /// </summary>
        /// <returns> Название пола пользователя. </returns>
        public override string ToString() => Name;
    }
}