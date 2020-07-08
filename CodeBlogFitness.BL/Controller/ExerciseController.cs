using CodeBlogFitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeBlogFitness.BL.Controller
{
    /// <summary>
    /// Контроллер выполнения упражнений.
    /// </summary>
    public class ExerciseController : BasicController
    {
        #region Свойства
        /// <summary>
        /// Пользователь.
        /// </summary>
        private readonly User user;

        /// <summary>
        /// Список упражнений пользователя.
        /// </summary>
        public List<Exercise> Exercises { get; }

        /// <summary>
        /// Список активностей пользователя.
        /// </summary>
        public List<Activity> Activities { get; }
        #endregion

        /// <summary>
        /// Создание контроллера выполнения упражнений.
        /// </summary>
        /// <param name="user"> Пользователь. </param>
        public ExerciseController(User user)
        {
            this.user = user ?? throw new ArgumentNullException(nameof(user));

            Exercises = GetAllExercises();
            Activities = GetAllActivities();
        }

        /// <summary>
        /// Добавить новое упражнение.
        /// </summary>
        /// <param name="activity"> Активность. </param>
        /// <param name="begin"> Время начала активности. </param>
        /// <param name="end"> Время конца активности. </param>
        public void Add(Activity activity, DateTime begin, DateTime end)
        {
            var act = Activities.FirstOrDefault(a => a.Name == activity.Name);

            if (act == null)
            {
                Activities.Add(activity);

                var exercise = new Exercise(begin, end, activity, user);
                Exercises.Add(exercise);
            }
            else
            {
                var exercise = new Exercise(begin, end, act, user);
                Exercises.Add(exercise);
            }            

            SaveAllExercises();
        }

        /// <summary>
        /// Получить список упражнений.
        /// </summary>
        /// <returns> Список упражнений. </returns>
        private List<Exercise> GetAllExercises()
        {
            return Load<Exercise>() ?? new List<Exercise>();
        }

        /// <summary>
        /// Получить список активностей пользователя.
        /// </summary>
        /// <returns> Список активностей пользователя. </returns>
        private List<Activity> GetAllActivities()
        {
            return Load<Activity>() ?? new List<Activity>();
        }

        /// <summary>
        /// Сохранить все упражнения.
        /// </summary>
        private void SaveAllExercises()
        {
            Save(Activities);
            Save(Exercises);
        }        
    }
}