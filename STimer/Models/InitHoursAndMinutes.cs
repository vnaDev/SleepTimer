using System.Collections.Generic;

namespace STimer.Models
{
    /// <summary>
    /// Инициализатор значений часов и минут
    /// </summary>
    public class InitHoursAndMinutes
    {
        /// <summary>
        /// Количество часов
        /// </summary>
        public List<string> Hours { get; set; }

        /// <summary>
        /// Количество минут
        /// </summary>
        public List<string> Minutes { get; set; }

        /// <summary>
        /// Конструктор
        /// </summary>
        public InitHoursAndMinutes()
        {
            Hours = GetHours();
            Minutes = GetMinutes();   
        }

        /// <summary>
        /// Получить значения часов
        /// </summary>
        /// <returns></returns>
        private List<string> GetHours()
        {
            List<string> hours = new List<string>();

            for (int i = 0; i < 24; i++)
                hours.Add(i.ToString());

            return hours;
        }

        /// <summary>
        /// Получить значения минут
        /// </summary>
        /// <returns></returns>
        private List<string> GetMinutes()
        {
            List<string> minutes = new List<string>();

            for (int i = 0; i < 60; i++)
                minutes.Add(i.ToString());

            return minutes;
        }
    }
}
