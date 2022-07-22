using STimer.Commands.Base;
using System.Windows;

namespace STimer.Commands
{
    /// <summary>
    /// Команда для завершения работы приложения
    /// </summary>
    public class ExitAppCommand : BaseCommand
    {
        public override void Execute(object? parameter) => Application.Current.Shutdown();
    }
}
