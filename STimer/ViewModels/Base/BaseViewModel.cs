using System.ComponentModel;

namespace STimer.ViewModels.Base
{
    /// <summary>
    /// Базовая модель представления
    /// </summary>
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Событие изменения свойства
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Обработчик PropertyChanged
        /// </summary>
        /// <param name="propertyName">Название изменившегося свойства</param>
        protected virtual void OnPropertyChanged(string propertyName) => PropertyChanged?
            .Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
