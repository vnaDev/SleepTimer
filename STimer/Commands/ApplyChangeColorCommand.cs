using STimer.Commands.Base;
using STimer.Stores;
using System.Windows.Media;

namespace STimer.Commands
{
    /// <summary>
    /// Команда применяет выбранный цвет
    /// </summary>
    public class ApplyChangeColorCommand : BaseCommand
    {
        private readonly NavigationStore _navigationStore;
        public ApplyChangeColorCommand(NavigationStore navigationStore) => _navigationStore = navigationStore;
        public override void Execute(object? parameter)
        {
            if (parameter == null) return;

            SolidColorBrush selectColorBrush = (SolidColorBrush)parameter;
            System.Windows.Application.Current.Resources["DynamicAppColor"] = selectColorBrush;
        }
    }
}
