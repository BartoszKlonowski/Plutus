using System;
using System.Windows.Input;


namespace App.Command
{
    public class RelayCommand : ICommand
    {
        // When calling the constructor it is needed to specify as an argument
        // the method which will be bound to the command in the View
        public RelayCommand( Action action )
        {
            actionToExecuteWhenLaunched = action;
        }


        public event EventHandler CanExecuteChanged = (sender, e) => { };


        // We want each command created with this base to be able to execute always
        // that's why we always just return true no matter of parameters
        public bool CanExecute( object parameter ) => true;


        // This method is executed when the command is launched from the View
        // The only responsibility of this base class Relay mechanism is to call the action
        // that is asssigned to it's instance during creation
        // (see the constructor implementation)
        public void Execute( object parameter )
        {
            actionToExecuteWhenLaunched();
        }


        private Action actionToExecuteWhenLaunched;
    }
}
