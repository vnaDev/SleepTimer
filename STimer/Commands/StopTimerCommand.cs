using STimer.Commands.Base;
using STimer.Stores;
using STimer.ViewModels;

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

            _navigationStore.CurrentViewModel = new SleepTimerEditViewModel(_navigationStore);
        }
        public override bool CanExecute(object? parameter) => true;
    }
}
