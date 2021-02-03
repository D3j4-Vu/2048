

using System;
using System.Windows.Input;

namespace _2048
{
    public class RelayCommand : ICommand
    {
        #region Private Members

        private bool canExecute;         
        private Action<object> mAction;

        #endregion
        #region Public Events

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        #endregion
        #region Constructor

        public RelayCommand(Action<object> action, bool canExecute = true)
        {
            this.canExecute = canExecute;
            mAction = action;
        }

        #endregion
        #region Command Methods

        public bool CanExecute(object parameter)
        {
            return canExecute;
        }

        public void Execute(object parameter)
        {
            mAction(parameter);
        }

        #endregion
    }
}

