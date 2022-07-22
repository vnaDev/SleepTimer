using STimer.Commands;
using STimer.Models;
using STimer.Stores;
using STimer.ViewModels.Base;
using System.Collections.Generic;
using System.Windows.Input;

namespace STimer.ViewModels
{
    /// <summary>
    /// Модель представления редактора таймера
    /// </summary>
    public class SleepTimerEditViewModel : BaseViewModel
    {
        /// <summary>
        /// Инициализация значений часов и минут
        /// </summary>
        private InitHoursAndMinutes _init;

        /// <summary>
        /// Список значений часов
        /// </summary>
        private List<string> _hours;

        /// <summary>
        /// Список значений минут
        /// </summary>
        private List<string> _minutes;

        /// <summary>
        /// Выбранный час
        /// </summary>
        private string _selectedHour;

        /// <summary>
        /// Выбранная минута
        /// </summary>
        private string _selectedMinute;

        public SleepTimerEditViewModel(NavigationStore navigationStore)
        {
            _init = new InitHoursAndMinutes();

            _hours = _init.Hours;
            _minutes = _init.Minutes;
            _selectedHour = _hours[0];
            _selectedMinute = _minutes[1];

            ApplyChangesCommand = new ApplyChangesTimerCommand(this, navigationStore);
            NavigateToSettingsCommand = new NavigateToSettingsCommand(navigationStore);
            ExitAppCommand = new ExitAppCommand();
        }

        /// <summary>
        /// Список значений часов
        /// </summary>
        public List<string> Hours
        {
            get => _hours;
            set
            {
                if (_hours == value) return;
                _hours = value;

                OnPropertyChanged("Hours");
            }
        }

        /// <summary>
        /// Список значений минут
        /// </summary>
        public List<string> Minutes
        {
            get => _minutes;
            set
            {
                if (_minutes == value) return;
                _minutes = value;

                OnPropertyChanged("Minutes");
            }
        }

        /// <summary>
        /// Выбранный час
        /// </summary>
        public string SelectedHour
        {
            get => _selectedHour;
            set
            {
                if (_selectedHour == value) return;
                _selectedHour = value;

                OnPropertyChanged("SelectedHour");
            }
        }

        /// <summary>
        /// Выбранная минута
        /// </summary>
        public string SelectedMinute
        {
            get => _selectedMinute;
            set
            {
                if (_selectedMinute == value) return;
                _selectedMinute = value;

                OnPropertyChanged("SelectedMinute");
            }
        }

        /// <summary>
        /// Команда - Принять изменения значений: количество часов, минут таймера
        /// </summary>
        public ICommand ApplyChangesCommand { get; }

        /// <summary>
        /// Команда для завершения работы приложения
        /// </summary>
        public ICommand ExitAppCommand { get; }

        /// <summary>
        /// Команда - Перейти в настройки
        /// </summary>
        public ICommand NavigateToSettingsCommand { get; }
    }
}
