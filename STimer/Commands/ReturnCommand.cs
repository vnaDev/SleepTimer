using STimer.Commands.Base;
using STimer.Stores;
using STimer.ViewModels;

namespace STimer.Commands
{
    /// <summary>
    /// Команда - назад
    /// </summary>
    public class ReturnCommand : BaseCommand
    {
        private readonly NavigationStore _navigationStore;
        public ReturnCommand(NavigationStore navigationStore) => _navigationStore = navigationStore;
        public override void Execute(object? parameter) => _navigationStore.CurrentViewModel = new SleepTimerEditViewModel(_navigationStore);
    }
}
