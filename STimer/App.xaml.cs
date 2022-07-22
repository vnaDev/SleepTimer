using STimer.Stores;
using STimer.ViewModels;
using STimer.ViewModels.MainViewModel;
using System.Windows;

namespace STimer
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Навигация приложения
        /// </summary>
        private readonly NavigationStore _navigationService;

        /// <summary>
        /// Конструктор
        /// </summary>
        public App() => _navigationService = new NavigationStore();

        /// <summary>
        /// Логика приложения в начале работы
        /// </summary>
        /// <param name="e"></param>
        protected override void OnStartup(StartupEventArgs e)
        {
            _navigationService.CurrentViewModel = new SleepTimerEditViewModel(_navigationService);

            MainWindow = new MainWindow() 
            { 
                DataContext = new MainWindowViewModel(_navigationService)
            };
            MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
