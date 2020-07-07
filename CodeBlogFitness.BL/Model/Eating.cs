using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Прием пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        #region Свойства
        /// <summary>
        /// Активный пользователь.
        /// </summary>
        public User User { get; }

        /// <summary>
        /// Момент приема пищи.
        /// </summary>
        public DateTime Moment { get; }

        /// <summary>
        /// Список приема пищи.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        #endregion

        /// <summary>
        /// Процесс приема пищи.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException("Пользователь не может быть равным null.", nameof(user));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }

        /// <summary>
        /// Добавить продукт в список.
        /// </summary>
        /// <param name="food"> Продукт. </param>
        /// <param name="weight"> Вес продукта в гр. </param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food.Name));

            if (product == null)
            {
                Foods.Add(food, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}