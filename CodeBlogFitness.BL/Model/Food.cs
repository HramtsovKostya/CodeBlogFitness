using System;

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
        /// Название продукта.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Калории на 1 гр. продукта.
        /// </summary>
        public double Calories { get; }

        /// <summary>
        /// Белки на 1 гр. продукта.
        /// </summary>
        public double Proteins { get; }

        /// <summary>
        /// Жиры на 1 гр. продукта.
        /// </summary>
        public double Fats { get; }       

        /// <summary>
        /// Углеводы на 1 гр. продукта.
        /// </summary>
        public double Сarbohydrates { get; }
        #endregion

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
        public Food(string name, double calories, double proteins, double fats, double carbohydrates)
        {
            Name = name;
            Calories = calories / 100.0;
            Proteins = proteins / 100.0;
            Fats = fats / 100.0;
            Сarbohydrates = carbohydrates / 100.0;            
        }

        public override string ToString() => Name;
    }    
}