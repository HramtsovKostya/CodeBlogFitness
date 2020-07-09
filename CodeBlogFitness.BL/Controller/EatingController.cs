using System;
using System.Collections.Generic;
using System.Linq;
using CodeBlogFitness.BL.Model;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер потребления пищи.
    /// </summary>
    public class EatingController : BasicController
    {
        #region Свойства       
        /// <summary>
        /// Активный пользователь.
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Список всех продуктов.
        /// </summary>
        private List<Food> Foods { get; }

        /// <summary>
        /// Справочник потребления пищи.
        /// </summary>
        public Eating Eating { get; }
        #endregion

        /// <summary>
        /// Создание контроллера потребления пищи.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public EatingController(User user)
        {
            this.user = user ?? throw new ArgumentNullException
                ("Пользователь не может быть равен null.", nameof(user));

            Foods = GetAllFoods();
            Eating = GetEating();
        }        
               
        /// <summary>
        /// Добавить продукт в справочник потребления пищи.
        /// </summary>
        /// <param name="food"> Продукт. </param>
        /// <param name="weight"> Вес продукта в гр. </param>
        public void Add(Food food, double weight)
        {
            var product = Foods
                .FirstOrDefault(prod => prod.Name == food.Name);

            if (product == null)
            {
                Foods.Add(food);
                Eating.Add(food, weight);                
            }
            else
            {
                Eating.Add(product, weight);
            }

            SaveEating();
        }

        /// <summary>
        /// Получить список всех продуктов.
        /// </summary>
        /// <returns> Список всех продуктов. </returns>
        private List<Food> GetAllFoods()
        {
            return Load<Food>() ?? new List<Food>();
        }

        /// <summary>
        /// Получить справочник потребления пищи.
        /// </summary>
        /// <returns> справочник потребления пищи. </returns>
        private Eating GetEating()
        {
            return Load<Eating>()
                .FirstOrDefault() ?? new Eating(user);
        }

        /// <summary>
        /// Сохранить список всех продуктов.
        /// </summary>
        private void SaveEating()
        {
            Save(Foods);
            Save(new List<Eating> { Eating });
        }
    }
}