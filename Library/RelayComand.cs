using System;
using System.Windows.Input;

namespace keyboard_emulator_windows.Library
{
    public class RelayCommand : ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object>? _canExecute;

        #pragma warning disable CS0067 // The event is never used
        public event EventHandler? CanExecuteChanged;
        #pragma warning restore CS0067

        public RelayCommand(Action<object> execute, Predicate<object>? canExecute = null)
        {
            if (execute == null) throw new ArgumentNullException(nameof(execute));
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute ==null || _canExecute(parameter ?? "<N/A>");
        }

        public void Execute(object? parameter)
        {
            _execute(parameter ?? "<N/A>");
        }
    }
}