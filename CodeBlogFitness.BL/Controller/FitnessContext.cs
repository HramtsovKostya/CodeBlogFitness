using CodeBlogFitness.BL.Model;
using System.Data.Entity;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контекст базы данных.
    /// </summary>
    public class FitnessContext : DbContext
    {
        /// <summary>
        /// Создание строки подключения.
        /// </summary>
        public FitnessContext() : base("DBConnection") { }

        #region Сущности базы данных.
        /// <summary>
        /// Активности пользователя.
        /// </summary>
        public DbSet<Activity> Activities { get; set; }

        /// <summary>
        /// Приемы пищи пользователя.
        /// </summary>
        public DbSet<Eating> Eatings { get; set; }

        /// <summary>
        /// Физические упражнения пользователя.
        /// </summary>
        public DbSet<Exercise> Exercises { get; set; }

        /// <summary>
        /// Потребленные продукты пользователя.
        /// </summary>
        public DbSet<Food> Foods { get; set; }

        /// <summary>
        /// Полы пользователей.
        /// </summary>
        public DbSet<Gender> Genders { get; set; }

        /// <summary>
        /// Пользователи приложения.
        /// </summary>
        public DbSet<User> Users { get; set; }
        #endregion
    }
}