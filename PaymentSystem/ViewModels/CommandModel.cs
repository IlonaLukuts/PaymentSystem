using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PaymentSystem.ViewModels
{
    public abstract class CommandModel
    {
        public RoutedUICommand Command { private set; get; }

        public CommandModel()
        {
            Command = new RoutedUICommand();
        }

        public abstract void OnExecute(object sender, ExecutedRoutedEventArgs e);

        public virtual void OnCanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
            e.Handled = true;
        }
    }
}
