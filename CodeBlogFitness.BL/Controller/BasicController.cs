using System.Collections.Generic;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Базовый контроллер данных.
    /// </summary>
    public abstract class BasicController
    {
        /// <summary>
        /// Менеджер сохранения и загрузки данных.
        /// </summary>
        private readonly IDateManager manager = new SerializationManager();

        /// <summary>
        /// Сохранение коллекции элементов.
        /// </summary>
        /// <typeparam name="T"> Тип элементов коллекции. </typeparam>
        /// <param name="collection"> Коллекция элементов. </param>
        protected void Save<T>(List<T> collection) where T : class => manager.Save(collection);

        /// <summary>
        /// Загрузка коллекции элементов.
        /// </summary>
        /// <typeparam name="T"> Тип элементов коллекции. </typeparam>
        /// <returns> Коллекция элементов. </returns>
        protected List<T> Load<T>() where T : class => manager.Load<T>();
    }
}