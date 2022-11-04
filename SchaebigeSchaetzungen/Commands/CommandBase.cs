using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchaebigeSchaetzungen.Commands
{
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public virtual bool CanExecute(object? parameter)//ob button gedrückt werden kann
        {
            return true; //Button kann standardmäßig  immer gedrückt werden
        }

        public abstract void Execute(object? parameter); //when button geklickt wird
        protected void OnCanExecuteChanged()
        { 
           CanExecuteChanged?.Invoke(this, new EventArgs());
        }
    }
}
