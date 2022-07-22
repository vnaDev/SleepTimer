using STimer.Commands.Base;
using STimer.Stores;
using STimer.ViewModels;

namespace STimer.Commands
{
    /// <summary>
    /// Команда перехода в настройки приложения
    /// </summary>
    public class NavigateToSettingsCommand : BaseCommand
    {
        private readonly NavigationStore _navigationStore;
        public NavigateToSettingsCommand(NavigationStore navigationStore) => _navigationStore = navigationStore;
        public override void Execute(object? parameter) => _navigationStore.CurrentViewModel = new EditColorViewModel(_navigationStore);
    }
}
