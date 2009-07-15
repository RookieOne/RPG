using System;
using System.Windows.Input;

namespace WpfFoundation.Commands
{
    /// <summary>
    /// Implements ICommand using an action
    /// </summary>
    public class ActionCommand : ICommand
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActionCommand"/> class.
        /// </summary>
        /// <param name="action">The action.</param>
        public ActionCommand(Action action)
        {
            _action = action;
        }

        private readonly Action _action;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (_action != null)
                _action.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}