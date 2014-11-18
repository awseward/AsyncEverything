using System;
using System.Windows.Input;

namespace WpfApplication
{
    public abstract class Command : ICommand
    {
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public abstract void Execute(object parameter);
    }

    public abstract class Command<T> : Command where T : ViewModel
    {
        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter) && parameter is T;
        }

        public override void Execute(object parameter)
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
