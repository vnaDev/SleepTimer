using System;
using System.Windows.Input;

namespace STimer.Commands.Base
{
    /// <summary>
    /// Базовая (абстрактная) команда
    /// </summary>
    public abstract class BaseCommand : ICommand
    {
        /// <summary>
        /// Событие - может - ли команда быть выполнена
        /// </summary>
        public event EventHandler? CanExecuteChanged;

        /// <summary>
        /// Обработчик события CanExecuteChanged
        /// </summary>
        protected void OnCanExecutedChanget() => CanExecuteChanged?.Invoke(this, new EventArgs());

        /// <summary>
        /// Может - ли команда быть выполнена
        /// </summary>
        /// <param name="parameter">Параметр события</param>
        /// <returns>если да - true, иначе false</returns>
        public virtual bool CanExecute(object? parameter) => true;

        /// <summary>
        /// Логика выполнения команды
        /// </summary>
        /// <param name="parameter">Параметр события</param>
        public abstract void Execute(object? parameter);
    }
}
