using STimer.Commands.Base;
using STimer.Stores;
using STimer.ViewModels;
using STimer.ViewModels.Base;
using System;

namespace STimer.Commands
{
    /// <summary>
    /// Команда - Принять изменения значений: количество часов, минут таймера
    /// </summary>
    public class ApplyChangesCommand : BaseCommand
    {
        private readonly SleepTimerEditViewModel _sleepTimerEditViewModel;
        private readonly NavigationStore _navigationStore;
        public ApplyChangesCommand(SleepTimerEditViewModel sleepTimerEditViewModel,
                                   NavigationStore navigationStore)
        {
            _sleepTimerEditViewModel = sleepTimerEditViewModel;
            _navigationStore = navigationStore;
        }

        public override void Execute(object? parameter)
        {
            int hour = int.Parse(_sleepTimerEditViewModel.SelectedHour);
            int minutes = int.Parse(_sleepTimerEditViewModel.SelectedMinute);
            TimeSpan startTimeSpan = new TimeSpan(hour, minutes, 0);

            _navigationStore.CurrentViewModel = GoToSleepTimer(
                _navigationStore, () => new SleepTimerViewModel(startTimeSpan, _navigationStore), startTimeSpan);
        }

        /// <summary>
        /// Перейти на SleepTimer
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="navigationStore"></param>
        /// <param name="value"></param>
        /// <param name="startTimeSpan"></param>
        /// <returns></returns>
        private BaseViewModel GoToSleepTimer<T>(NavigationStore navigationStore, Func<T> value, TimeSpan startTimeSpan) => 
            new SleepTimerViewModel(startTimeSpan, navigationStore);
    }
}
