using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplication
{
    public abstract class Cmd : ICommand
    {
        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public virtual void Execute(object parameter)
        {
            if (!SetUpSteps(parameter)) { return; }

            try
            {
                _execution();
            }
            catch (Exception ex)
            {
                _error(ex);
            }
            finally
            {
                _ensure();
            }
        }

        protected abstract bool SetUpSteps(object parameter);

        protected Action<Exception> _error = (ex) => { };

        protected Action _execution = () => { };

        protected Action _ensure = () => { };
    }

    public abstract class Cmd<T> : Cmd where T : ViewModel
    {
        public override bool CanExecute(object parameter)
        {
            return base.CanExecute(parameter)
                && parameter != null
                && parameter is T;
        }

        protected override bool SetUpSteps(object parameter)
        {
            if (parameter is T)
            {
                var viewModel = (T) parameter;
                return SetUpSteps(viewModel);
            }

            return false;
        }

        protected abstract bool SetUpSteps(T viewModel);
    }
}
