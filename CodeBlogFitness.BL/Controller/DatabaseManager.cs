using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Менеджер базы данных.
    /// </summary>
    public class DatabaseManager : IDateManager
    {
        /// <summary>
        /// Загрузка коллекции элементов из базы данных.
        /// </summary>
        /// <typeparam name="T"> Тип элементов коллекции. </typeparam>
        /// <returns> Коллекция элементов. </returns>
        public List<T> Load<T>() where T : class
        {
            using (var context = new FitnessContext())
            {
                var collection = context.Set<T>().Where(t => true).ToList();
                return collection;
            }
        }

        /// <summary>
        /// Сохранение коллекции элементов в базу данных.
        /// </summary>
        /// <typeparam name="T"> Тип элементов коллекции. </typeparam>
        /// <param name="collection"> Коллекция элементов. </param>
        public void Save<T>(List<T> collection) where T : class
        {
            using (var context = new FitnessContext())
            {
                context.Set<T>().AddRange(collection);
                context.SaveChanges();
            }
        }
    }
}
