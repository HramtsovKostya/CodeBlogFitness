using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Потребление пищи.
    /// </summary>
    [Serializable]
    public class Eating
    {
        #region Свойства
        /// <summary>
        /// Идентификатор потребления приема.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя. 
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Активный пользователь.
        /// </summary>
        public virtual User User { get; set; }

        /// <summary>
        /// Момент приема пищи.
        /// </summary>
        public DateTime Moment { get; set; }

        /// <summary>
        /// Список приема пищи.
        /// </summary>
        public Dictionary<Food, double> Foods { get; set; }
        #endregion

        /// <summary>
        /// Процесс приема пищи.
        /// </summary>
        public Eating() { }

        /// <summary>
        /// Процесс приема пищи.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public Eating(User user)
        {
            User = user ?? throw new ArgumentNullException
                ("Пользователь не может быть равным null.", nameof(user));
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