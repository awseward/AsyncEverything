using System;
using System.Windows.Input;

namespace WpfApplication
{
    public abstract class Command<T> : ICommand where T : ViewModel
    {
        public virtual bool CanExecute(object parameter)
        {
            return parameter != null
                && parameter is T;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (parameter is T)
            {
                var viewModel = (T) parameter;
                Execute(viewModel);
            }
        }

        protected abstract void Execute(T viewModel);
    }
}
