using STimer.Commands;
using STimer.Stores;
using STimer.ViewModels.Base;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace STimer.ViewModels
{
    /// <summary>
    /// Модель представления таймера
    /// </summary>
    public class SleepTimerViewModel : BaseViewModel
    {
        /// <summary>
        /// Таймер
        /// </summary>
        private DispatcherTimer _timer;

        /// <summary>
        /// Начальное время до окончания таймера
        /// </summary>
        private TimeSpan _startTimeSpan;

        /// <summary>
        /// Время запуска таймера
        /// </summary>
        private DateTime _startCountdown;

        /// <summary>
        /// Интервал срабатывания тика таймера
        /// </summary>
        private readonly TimeSpan _interval = TimeSpan.FromMilliseconds(15);

        /// <summary>
        /// Время до окончания таймера
        /// </summary>
        private TimeSpan _timeToEnd;

        public bool isCloseTimer;
        private bool isOneMinuteOK;

        /// <summary>
        /// Конструктор модели представления таймера
        /// </summary>
        /// <param name="startTimeSpan">Начальное время до окончания таймера</param>
        public SleepTimerViewModel(TimeSpan startTimeSpan, NavigationStore navigationStore)
        {
            _startTimeSpan = startTimeSpan;

            _timer = new DispatcherTimer();
            _timer.Interval = _interval;
            _timer.Tick += Timer_Tick;
            StopTimer();

            StartTimerCommand = new StartTimerCommand(this);
            StopTimerCommand = new StopTimerCommand(this, navigationStore);
            NavigateToSettingsCommand = new NavigateToSettingsCommand(navigationStore);
            ExitAppCommand = new ExitAppCommand();
        }

        /// <summary>
        /// Тик таймера
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer_Tick(object? sender, EventArgs e)
        {
            if (isCloseTimer) _timer.Stop();

            var now = DateTime.Now;
            var elapsed = now.Subtract(_startCountdown);
            TimeToEnd = _startTimeSpan.Subtract(elapsed);
        }

        /// <summary>
        /// Запустить таймер
        /// </summary>
        /// <param name="startDate">Время запуска таймера</param>
        public void StartTimer()
        {
            isCloseTimer = false;

            if (_timer.IsEnabled) return;

            _startCountdown = DateTime.Now;
            _timer.Start();
        }

        /// <summary>
        /// Остановить таймер
        /// </summary>
        public void StopTimer()
        {
            _timer.Stop();
            TimeToEnd = _startTimeSpan;
        }

        /// <summary>
        /// Таймер включен
        /// </summary>
        public bool TimerIsEnabled => _timer.IsEnabled;

        /// <summary>
        /// Время до окончания таймера
        /// </summary>
        public TimeSpan TimeToEnd
        {
            get => _timeToEnd;
            set
            {
                _timeToEnd = value;

                if (_timeToEnd.Minutes < 1 && !isOneMinuteOK)
                {
                    //когда значение таймера меньше минуты окно появляеться поверх всех
                    Application.Current.MainWindow.WindowState = WindowState.Normal;
                    isOneMinuteOK = true;
                }

                if (_timeToEnd.TotalMilliseconds <= 0)
                {
                    StopTimer();

                    //действия при окончании таймера - выключение компьютера
                    System.Diagnostics.Process.Start("shutdown", "/s /t 0 /f");
                }

                OnPropertyChanged("StringCountdown");
            }
        }

        /// <summary>
        /// Возвращает строку значений таймера
        /// </summary>
        public string StringCountdown
        {
            get
            {
                var frht = TimeToEnd.Hours < 1 ? "mm\\:ss" : "hh\\:mm";
                return TimeToEnd.ToString(frht);
            }
        }

        /// <summary>
        /// Команда для запуска таймера
        /// </summary>
        public ICommand StartTimerCommand { get; }

        /// <summary>
        /// Команда для остановки таймера
        /// </summary>
        public ICommand StopTimerCommand { get; }

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
