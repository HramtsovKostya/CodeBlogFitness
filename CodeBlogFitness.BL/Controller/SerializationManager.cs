using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Менеджер сериализации данных.
    /// </summary>
    public class SerializationManager : IDateManager
    {
        /// <summary>
        /// Путь к файлу данных.
        /// </summary>
        private const string PATH = @"Saves\";        

        /// <summary>
        /// Сохранение коллекции элементов в файл.
        /// </summary>
        /// <typeparam name="T"> Тип элементов коллекции. </typeparam>
        /// <param name="collection"> Коллекция элементов. </param>
        public void Save<T>(List<T> collection) where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name + ".dat";

            using (var file = new FileStream(PATH + fileName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(file, collection);
            }
        }

        /// <summary>
        /// Загрузка коллекции элементов из файла.
        /// </summary>
        /// <typeparam name="T"> Тип элементов коллекции. </typeparam>
        /// <returns> Коллекция элементов. </returns>
        public List<T> Load<T>() where T : class
        {
            var formatter = new BinaryFormatter();
            var fileName = typeof(T).Name + ".dat";

            using (var file = new FileStream(PATH + fileName, FileMode.OpenOrCreate))
            {
                if (file.Length > 0)
                {
                    return formatter.Deserialize(file) as List<T>;
                }
                else
                {
                    return new List<T>();
                }
            }
        }
    }
}