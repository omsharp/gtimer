using System;
using System.Windows.Input;

namespace GTimer
{
   public class RelayCommand : ICommand
   {
      private readonly Action execute;
      private readonly Func<bool> canExecute;

      public RelayCommand(Action methodToExecute, Func<bool> canExecuteEvaluator)
      {
         execute = methodToExecute;
         canExecute = canExecuteEvaluator;
      }

      public event EventHandler CanExecuteChanged
      {
         add { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }
      }

      public RelayCommand(Action methodToExecute)
          : this(methodToExecute, null)
      {
      }

      public bool CanExecute(object parameter)
      {
         return canExecute == null ? true : canExecute.Invoke();
      }

      public void Execute(object parameter)
      {
         execute?.Invoke();
      }
   }

   public class RelayCommand<T> : ICommand
   {
      private readonly Action<T> execute;
      private readonly Func<bool> canExecute;

      public RelayCommand(Action<T> methodToExecute, Func<bool> canExecuteEvaluator)
      {
         execute = methodToExecute;
         canExecute = canExecuteEvaluator;
      }

      public event EventHandler CanExecuteChanged
      {
         add { CommandManager.RequerySuggested += value; }
         remove { CommandManager.RequerySuggested -= value; }
      }

      public RelayCommand(Action<T> methodToExecute)
          : this(methodToExecute, null)
      {
      }

      public bool CanExecute(object parameter)
      {
         return canExecute == null ? true : canExecute.Invoke();
      }

      public void Execute(object parameter)
      {
         execute?.Invoke((T)parameter);
      }
   }
}
