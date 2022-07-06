using STimer.Stores;
using STimer.ViewModels.Base;

namespace STimer.ViewModels.MainViewModel
{
    /// <summary>
    /// Модель представления главного окна
    /// </summary>
    public class MainWindowViewModel : BaseViewModel
    {
        /// <summary>
        /// Навигация приложения
        /// </summary>
        private readonly NavigationStore _navigationStore;

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="navigationStore">Навигация приложения</param>
        public MainWindowViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
        }

        /// <summary>
        /// Событие изменения модели представления
        /// </summary>
        private void OnCurrentViewModelChanged() => OnPropertyChanged(nameof(CurrentViewModel));

        /// <summary>
        /// Текущая модель представления
        /// </summary>
        public BaseViewModel CurrentViewModel => _navigationStore.CurrentViewModel;
    }
}
