using STimer.Commands.Base;
using STimer.Stores;
using STimer.ViewModels.Base;
using System;

namespace STimer.Commands
{
    /// <summary>
    /// Команда навигации
    /// </summary>
    public class NavigateCommand<TViewModel> : BaseCommand
        where TViewModel : BaseViewModel
    {
        /// <summary>
        /// Навигация приложения
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Создать модель представления
        /// </summary>
        private readonly Func<TViewModel> _createViewModel;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="navigationStore">Навигация приложения</param>
        public NavigateCommand(NavigationStore navigationStore,
                               Func<TViewModel> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }

        /// <summary>
        /// Логика выполнения команды навигации
        /// </summary>
        /// <param name="parameter">Параметр команды</param>
        public override void Execute(object? parameter) => 
            _navigationStore.CurrentViewModel = _createViewModel();
    }
}
