using App.Models;

namespace App.ViewModels.Facade
{
    // Represents the Facade design pattern which is responsible for providing convenient access
    // to a particular part of the subsystem’s functionality.
    // It's easier to call this one Facade every time and choose the subclass it manages
    // instead of calling each subclass (or even worse - construct it) every time it's use is necessary
    public class ViewModelFacade
    {
        public ViewModelFacade()
        {
            Chart = new ChartViewModel();
            Wallet = new WalletViewModel();
            User = User.Instance;

            RegisterChartAsAnObserver();
        }


        private void RegisterChartAsAnObserver()
        {
            Wallet.Attach( Chart );
        }

        // Sometimes the Facade pattern can also cover part of logic that is implemented by it's subclasses
        // In our case it's not necessarly and would cause a lot of overengineering instead of improvements.

        // Subclasses of Facade
        public ChartViewModel Chart { get; }
        public WalletViewModel Wallet { get; }
        public User User { get; }
    }
}
