using System;
using System.Collections.Generic;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Продукт.
    /// </summary>
    [Serializable]
    public class Food
    {
        #region Свойства
        /// <summary>
        /// Идентификатор продукта.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Название продукта.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Калории на 1 гр. продукта.
        /// </summary>
        public double Calories { get; set; }

        /// <summary>
        /// Белки на 1 гр. продукта.
        /// </summary>
        public double Proteins { get; set; }

        /// <summary>
        /// Жиры на 1 гр. продукта.
        /// </summary>
        public double Fats { get; set; }       

        /// <summary>
        /// Углеводы на 1 гр. продукта.
        /// </summary>
        public double Сarbohydrates { get; set; }

        /// <summary>
        /// Коллекция приемов пищи.
        /// </summary>
        public virtual ICollection<Eating> Eatings { get; set; }
        #endregion

        /// <summary>
        /// Добавить новый продукт.
        /// </summary>
        public Food() { }

        /// <summary>
        /// Задать название продукта.
        /// </summary>
        /// <param name="name"> Название продукта. </param>
        public Food(string name) : this(name, 0, 0, 0, 0) { }

        /// <summary>
        /// Добавить новый продукт.
        /// </summary>
        /// <param name="name"> Название продукта. </param>
        /// <param name="calories"> Калории на 100 г. продукта. </param>
        /// <param name="proteins"> Белки на 100 г. продукта. </param>
        /// <param name="fats"> Жиры на 100 г. продукта. </param>
        /// <param name="carbohydrates"> Углеводы на 100 г. продукта. </param>
        public Food(string name,
                double calories,
                double proteins,
                double fats,
                double carbohydrates)
        {
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Сarbohydrates = carbohydrates / 100.0;            
        }

        /// <summary>
        /// Преобразование в строковый тип.
        /// </summary>
        /// <returns> Название продукта. </returns>
        public override string ToString() => Name;
    }    
}