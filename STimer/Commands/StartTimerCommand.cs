using STimer.Commands.Base;
using STimer.ViewModels;

namespace STimer.Commands
{
    /// <summary>
    /// Команда для запуска таймера
    /// </summary>
    public class StartTimerCommand : BaseCommand
    {
        private readonly SleepTimerViewModel _sleepTimerViewModel;
        public StartTimerCommand(SleepTimerViewModel sleepTimerViewModel) => _sleepTimerViewModel = sleepTimerViewModel;
        public override void Execute(object? parameter) => _sleepTimerViewModel.StartTimer();
        public override bool CanExecute(object? parameter)
        {
            bool isEnabled = _sleepTimerViewModel.TimerIsEnabled;
            if (isEnabled) return false;
            else return true;
        }
    }
}
