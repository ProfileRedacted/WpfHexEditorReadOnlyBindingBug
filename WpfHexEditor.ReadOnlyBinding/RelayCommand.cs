using System;
using System.Windows.Input;

namespace WpfHexEditor.ReadOnlyBinding {

    public class RelayCommand : RelayCommand<object> {

        public RelayCommand(Action execute, Predicate<object> canExecute = null) : base((param) => execute(), (param) => canExecute?.Invoke(null) ?? true) {
        }

    }

    public class RelayCommand<T> : ICommand {

        #region Fields

        private readonly Action<T> execute;
        private readonly Predicate<T> canExecute;

        #endregion

        /// <summary>
        /// Creates a new command.
        /// </summary>
        /// <param name="execute">The execution logic.</param>
        /// <param name="canExecute">The execution status logic.</param>
        public RelayCommand(Action<T> execute, Predicate<T> canExecute = null) {
            this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
        }

        #region ICommand

        /// <summary>
        /// Defines the method that determines whether the command can execute in its current state.
        /// </summary>
        /// <param name="parameter">Data used by the command.  If the command does not require data to be passed, this object can be set to null.</param>
        /// <returns>
        /// True if this command can be executed; otherwise, false.
        /// </returns>
        public bool CanExecute(object parameter) {
            return canExecute == null || canExecute((T)parameter);
        }

        /// <summary>
        /// Occurs when changes occur that affect whether or not the command should execute.
        /// </summary>
        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        /// <summary>
        /// Defines the method to be called when the command is invoked.
        /// </summary>
        /// <param name="parameter">Data used by the command. If the command does not require data to be passed, this object can be set to <see langword="null" />.</param>
        public void Execute(object parameter) {
            execute((T)parameter);
        }

        #endregion
    }

}
