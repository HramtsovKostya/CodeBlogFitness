using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Базовый контроллер данных.
    /// </summary>
    public abstract class ControllerBase
    {
        /// <summary>
        /// Путь к файлу сохранения.
        /// </summary>
        private const string PATH = @"Saves\";

        /// <summary>
        /// Сохранение данных в файл.
        /// </summary>
        /// <typeparam name="T"> Тип данных. </typeparam>
        /// <param name="collection"> Список данных. </param>
        /// <param name="fileName"> Файл сохранения. </param>
        protected void Save(object item, string fileName)
        {
            using (var file = new FileStream(PATH + fileName, FileMode.OpenOrCreate))
            {
                new BinaryFormatter().Serialize(file, item);
            }
        }

        /// <summary>
        /// Получение данных из файла.
        /// </summary>
        /// <typeparam name="T"> Тип данных. </typeparam>
        /// <param name="fileName"> Файл загрузки. </param>
        /// <returns> Список данных. </returns>
        protected T Load<T>(string fileName)
        {
            using (var file = new FileStream(PATH + fileName, FileMode.OpenOrCreate))
            {
                return file.Length > 0 && new BinaryFormatter().Deserialize(file) is T item ? item : default;
            }
        }
    }
}