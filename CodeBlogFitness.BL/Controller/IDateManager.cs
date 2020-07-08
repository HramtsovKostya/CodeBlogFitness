using System.Collections.Generic;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Интерфейс сохранения и загрузки данных.
    /// </summary>
    public interface IDateManager
    {
        /// <summary>
        /// Сохранение коллекции элементов.
        /// </summary>
        /// <typeparam name="T"> Тип элементов коллекции. </typeparam>
        /// <param name="collectiobn"> Коллекция элементов. </param>
        void Save<T>(List<T> collection) where T : class;

        /// <summary>
        /// Загрузка коллекции элементов.
        /// </summary>
        /// <typeparam name="T"> Тип элементов коллекции. </typeparam>
        /// <returns> Коллекция элементов. </returns>
        List<T> Load<T>() where T : class; 
    }
}