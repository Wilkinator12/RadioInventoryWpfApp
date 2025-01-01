using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RadioInventoryWpfUI.Commands
{
    public class MyICommand<T> : ICommand
    {
        Action<T?> _targetExecuteMethod;
        Func<T?, bool>? _targetCanExecuteMethod;



        public MyICommand(Action<T?> executeMethod)
        {
            _targetExecuteMethod = executeMethod;
        }

        public MyICommand(Action<T?> executeMethod, Func<T?, bool> canExecuteMethod)
        {
            _targetExecuteMethod = executeMethod;
            _targetCanExecuteMethod = canExecuteMethod;
        }



        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }



        public bool CanExecute(object? parameter)
        {
            if (_targetCanExecuteMethod != null) return _targetCanExecuteMethod((T?)parameter);

            return true;
        }

        public void Execute(object? parameter)
        {
            _targetExecuteMethod((T?)parameter);
        }
    }
}
