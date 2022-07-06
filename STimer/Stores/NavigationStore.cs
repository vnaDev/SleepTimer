using STimer.ViewModels.Base;
using System;

namespace STimer.Stores
{
    /// <summary>
    /// Навигация приложения
    /// </summary>
    public class NavigationStore
    {
        /// <summary>
        /// Текущая модель представления
        /// </summary>
        private BaseViewModel? _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get => _currentViewModel ?? throw new Exception("Значение текущей модели предствления - null");
            set
            {
                _currentViewModel = value;
                OnCurrentViewModelChanged();
            }
        }

        /// <summary>
        /// Событие изменения текущей модели представления
        /// </summary>
        public event Action? CurrentViewModelChanged;

        /// <summary>
        /// Обработчик CurrentViewModelChanged
        /// </summary>
        private void OnCurrentViewModelChanged() => CurrentViewModelChanged?.Invoke();
    }
}
