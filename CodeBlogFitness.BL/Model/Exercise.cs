using System;

namespace CodeBlogFitness.BL.Model
{
    /// <summary>
    /// Физическое упражнение.
    /// </summary>
    [Serializable]
    public class Exercise
    {
        #region Свойства
        /// <summary>
        /// Идентификатор упражнения.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор пользователя.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Идентификатор активности.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Время начала упражнения.
        /// </summary>
        public DateTime Start { get; set; }

        /// <summary>
        /// Время конца упражнения.
        /// </summary>
        public DateTime Finish { get; set; }

        /// <summary>
        /// Физическая активность.
        /// </summary>
        public virtual Activity Activity { get; set; }
    
        /// <summary>
        /// Пользователь.
        /// </summary>
        public virtual User User { get; set; }
        #endregion

        /// <summary>
        /// Добавить новое упражнение.
        /// </summary>
        public Exercise() { }

        /// <summary>
        /// Добавить новое упражнение.
        /// </summary>
        /// <param name="start"> Время начала упражнения. </param>
        /// <param name="finish"> Время конца упражнения. </param>
        /// <param name="activity"> Физическая активность. </param>
        /// <param name="user"> Пользователь. </param>
        public Exercise(DateTime start, DateTime finish, Activity activity, User user)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            User = user;
        }
    }
}