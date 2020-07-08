using System;
using System.Collections.Generic;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Физическая активность.
    /// </summary>
    [Serializable]
    public class Activity
    {
        #region Свойства
        /// <summary>
        /// Идентификатор активности.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название активности.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Расход энергии в минуту.
        /// </summary>
        public double CaloriesPerMinute { get; set; }

        /// <summary>
        /// Коллекция упражнений.
        /// </summary>
        public virtual ICollection<Exercise> Exercises { get; set; }
        #endregion

        /// <summary>
        /// Добавить новую активность.
        /// </summary>
        public Activity() { }

        /// <summary>
        /// Добавить новую активность.
        /// </summary>
        /// <param name="name"> Название активности. </param>
        /// <param name="caloriesPerMinute"> Расход энергии в минуту. </param>
        public Activity(string name, double caloriesPerMinute)
        {
            Name = name;
            CaloriesPerMinute = caloriesPerMinute;
        }        

        /// <summary>
        /// Преобразование к строковому типу.
        /// </summary>
        /// <returns> Название активности. </returns>
        public override string ToString() => Name;
    }
}