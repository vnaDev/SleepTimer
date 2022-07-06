using STimer.Commands.Base;
using STimer.Stores;
using STimer.ViewModels;
using STimer.ViewModels.Base;
using System;

namespace STimer.Commands
{
    /// <summary>
    /// Команда для остановки таймера
    /// </summary>
    public class StopTimerCommand : BaseCommand
    {
        private readonly SleepTimerViewModel _sleepTimerViewModel;
        private readonly NavigationStore _navigationStore;
        public StopTimerCommand(SleepTimerViewModel sleepTimerViewModel, NavigationStore navigationService)
        {
            _sleepTimerViewModel = sleepTimerViewModel;
            _navigationStore = navigationService;
        }

        public override void Execute(object? parameter)
        {
            _sleepTimerViewModel.isCloseTimer = true;
            _sleepTimerViewModel.StopTimer();

            _navigationStore.CurrentViewModel = GoToSleepTimerEdit(
                _navigationStore, () => new SleepTimerEditViewModel(_navigationStore));
        }

        /// <summary>
        /// Перейти на SleepTimerEdit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="navigationStore"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private BaseViewModel GoToSleepTimerEdit<T>(NavigationStore navigationStore, Func<T> value) => 
            new SleepTimerEditViewModel(_navigationStore);
        public override bool CanExecute(object? parameter) => true;
    }
}
