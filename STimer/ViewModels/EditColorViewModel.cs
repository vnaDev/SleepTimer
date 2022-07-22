using STimer.Commands;
using STimer.Stores;
using STimer.ViewModels.Base;
using System.Windows.Input;

namespace STimer.ViewModels
{
    /// <summary>
    /// Модель представления изменения цвета
    /// </summary>
    public class EditColorViewModel : BaseViewModel
    {
        public EditColorViewModel(NavigationStore navigationStore)
        {
            ApplyChangeColorCommand = new ApplyChangeColorCommand(navigationStore);
            ReturnCommand = new ReturnCommand(navigationStore);
            ExitAppCommand = new ExitAppCommand();
        }

        /// <summary>
        /// Команда - Изменить цвет
        /// </summary>
        public ICommand ApplyChangeColorCommand { get; }

        /// <summary>
        /// Команда - Назад
        /// </summary>
        public ICommand ReturnCommand { get; }

        /// <summary>
        /// Команда для завершения работы приложения
        /// </summary>
        public ICommand ExitAppCommand { get; }
    }
}
